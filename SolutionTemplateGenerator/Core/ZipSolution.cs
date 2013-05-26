using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using SolutionTemplateGenerator.Core.ManifestCreator;
using SolutionTemplateGenerator.Core.Preprocessor;
using SolutionTemplateGenerator.Core.Utils;
using SolutionTemplateGenerator.Models;

namespace SolutionTemplateGenerator.Core
{
    public class ZipSolution
    {
        #region Fields (5)

        int _folderOffset;
        int _minInstallPathLength;
        string _solutionFolder;
        ZipOutputStream _zipStream;
        const int MaxPath = 248;

        #endregion Fields

        #region Properties (6)

        public string Comment { set; get; }

        public bool IncludeSubfolders { set; get; }

        public int NumberOfProjects { set; get; }

        public OptionsGui OptionsGuiData { set; get; }

        public string OutPathname { set; get; }

        public IList<string> ProjectFiles { set; get; }

        #endregion Properties

        #region Methods (21)

        // Public Methods (1) 

        public void ZipFolder()
        {
            setBaseLen();
            createSolutionTemplate();
            createVsixFile();
        }
        // Private Methods (20) 

        private void addContentTypes()
        {
            var content = ResourceFile.GetInputFile("SolutionTemplateGenerator.Resources.[Content_Types].xml");
            addFileEntry(Path.Combine(_solutionFolder, "[Content_Types].xml"), content);
        }

        private void addFileEntry(string filePath, byte[] content, bool replaceSafeprojectname = true)
        {
            var entryName = filePath.Substring(_folderOffset);
            if (replaceSafeprojectname)
            {
                entryName = entryName.Replace(OptionsGuiData.DefaultNamespace, "$saferootprojectname$");
            }
            entryName = ZipEntry.CleanName(entryName);

            checkPathLength(entryName);

            var newEntry = new ZipEntry(entryName)
            {
                DateTime = DateTime.Now,
                Size = content.Length,
                IsUnicodeText = true
            };
            _zipStream.PutNextEntry(newEntry);

            var buffer = new byte[4096];
            using (var streamReader = new MemoryStream(content))
            {
                StreamUtils.Copy(streamReader, _zipStream, buffer);
            }
            _zipStream.CloseEntry();
        }

        private void addFiles(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var filePath in files)
            {
                if (ignorePath(filePath))
                    continue;

                addProjectVSTemplate(filePath);

                var content = ModifyFactory.ProcessFile(filePath, OptionsGuiData.DefaultNamespace);
                addFileEntry(filePath, content);
            }
        }

        private void addIconImage(string dir)
        {
            if (File.Exists(OptionsGuiData.IconImagePath))
            {
                var filePath = Path.Combine(dir, OptionsGuiData.IconImagePath.GetFileName());
                addFileEntry(Path.Combine(dir, "__Template_small.png"), File.ReadAllBytes(filePath));
            }
            else
            {
                var content = ResourceFile.GetInputFile("SolutionTemplateGenerator.Resources.__Template_small.png");
                addFileEntry(Path.Combine(dir, "__Template_small.png"), content);
            }
        }

        private void addLicenseFile(string dir)
        {
            if (File.Exists(OptionsGuiData.LicenseFilePath))
            {
                var name = OptionsGuiData.LicenseFilePath.GetFileName();
                var filePath = Path.Combine(dir, name);
                addFileEntry(Path.Combine(dir, Uri.EscapeUriString(name)), File.ReadAllBytes(filePath));
            }
            else
            {
                var content = ResourceFile.GetInputFile("SolutionTemplateGenerator.Resources.MIT.txt");
                addFileEntry(Path.Combine(dir, Uri.EscapeUriString("MIT.txt")), content);
            }
        }

        private void addPreviewImage(string dir)
        {
            if (File.Exists(OptionsGuiData.PreviewImagePath))
            {
                var filePath = Path.Combine(dir, OptionsGuiData.PreviewImagePath.GetFileName());
                addFileEntry(Path.Combine(dir, "__Template_large.png"), File.ReadAllBytes(filePath));
            }
            else
            {
                var content = ResourceFile.GetInputFile("SolutionTemplateGenerator.Resources.__Template_large.png");
                addFileEntry(Path.Combine(dir, "__Template_large.png"), content);
            }
        }

        private void addProjectVSTemplate(string path)
        {
            if (path.EndsWith(".csproj", StringComparison.InvariantCultureIgnoreCase) ||
               path.EndsWith(".vbproj", StringComparison.InvariantCultureIgnoreCase))
            {
                var dir = path.GetDirectoryName();
                var filePath = Path.Combine(dir, "MyTemplate.vstemplate");
                var vsTemplate = ProjectVSTemplateCreator.GetProjectVSTemplate(OptionsGuiData, path);
                var vsTemplateContent = Encoding.UTF8.GetBytes(vsTemplate);
                addFileEntry(filePath, vsTemplateContent);
            }
        }

        private void addSolutionTemplate()
        {
            if (string.IsNullOrWhiteSpace(OptionsGuiData.ProjectSubType))
            {
                OptionsGuiData.ProjectSubType = "Windows";
            }

            var path = Path.Combine(_solutionFolder, VsixManifestCreator.TemplatePath + "\\" + Uri.EscapeUriString(OptionsGuiData.ProjectSubType) + "\\" + Uri.EscapeUriString(OutPathname.GetFileName()));
            addFileEntry(path, File.ReadAllBytes(OutPathname), replaceSafeprojectname: false);
        }

        private void addSolutionVSTemplate()
        {
            var solutionVSTemplate = SolutionVSTemplateCreator.GetSolutionVSTemplate(OptionsGuiData);
            var solutionVSTemplateContent = Encoding.UTF8.GetBytes(solutionVSTemplate);
            var dir = OptionsGuiData.SolutionPath.GetDirectoryName();
            var filePath = Path.Combine(dir, "MyTemplate.vstemplate");
            addFileEntry(filePath, solutionVSTemplateContent);
        }

        private void addSolutionVSTemplateImages()
        {
            var dir = OptionsGuiData.SolutionPath.GetDirectoryName();
            addIconImage(dir);
            addPreviewImage(dir);
        }

        private void addVsixManifest()
        {
            var vsixManifest = VsixManifestCreator.GetVsixManifest(OptionsGuiData);
            var vsixManifestContent = Encoding.UTF8.GetBytes(vsixManifest);
            addFileEntry(Path.Combine(_solutionFolder, "extension.vsixmanifest"), vsixManifestContent);
        }

        private void checkPathLength(string entryName)
        {
            var len = _minInstallPathLength + entryName.Length;
            if (len >= MaxPath)
            {
                throw new PathTooLongException(string.Format("Path: `{0}`{1}with actual installation path length = {2} is too long (>= MAX_PATH)  to be installed by VSIX installer.{1}Possible solutions: decrease the length of author/product/sub type/project files names.", entryName, Environment.NewLine, len));
            }
        }

        private void close()
        {
            _zipStream.IsStreamOwner = true;
            _zipStream.Close();
        }

        private void compressFolder(string path)
        {
            addFiles(path);

            if (!IncludeSubfolders)
                return;

            var folders = Directory.GetDirectories(path);
            foreach (var folder in folders)
            {
                compressFolder(folder);
            }
        }

        private void createSolutionTemplate()
        {
            try
            {
                initSolutionTemplate();
                if (NumberOfProjects > 1)
                {
                    addSolutionVSTemplate();
                    addSolutionVSTemplateImages();
                }
                foreach (var project in ProjectFiles)
                {
                    var folder = project.GetDirectoryName();
                    compressFolder(folder);
                }
            }
            finally
            {
                close();
            }
        }

        private void createVsixFile()
        {
            try
            {
                initVsixFile();
                addVsixManifest();
                addIconImage(_solutionFolder);
                addPreviewImage(_solutionFolder);
                addLicenseFile(_solutionFolder);
                addContentTypes();
                addSolutionTemplate();
                addWizardAssembly();
            }
            finally
            {
                close();
            }
        }

        private void addWizardAssembly()
        {
            var path = typeof(SafeRootProjectWizard.ChildWizard).Assembly.Location;
            var name = path.GetFileName();
            var content = File.ReadAllBytes(path);
            addFileEntry(Path.Combine(_solutionFolder, name), content);   
        }

        private bool ignorePath(string filePath)
        {
            if (filePath.Equals(OutPathname, StringComparison.InvariantCultureIgnoreCase))
                return true;

            if (filePath.ToLowerInvariant().Contains("\\bin") || filePath.ToLowerInvariant().Contains("\\obj"))
                return true;

            if (filePath.Replace(_solutionFolder, string.Empty).TrimStart(new[] { '\\' }).StartsWith("packages", StringComparison.InvariantCultureIgnoreCase))
                return true;

            if (filePath.EndsWith(".sln", StringComparison.InvariantCultureIgnoreCase))
                return true;

            return false;
        }

        private void initSolutionTemplate()
        {
            var fsOut = File.Create(OutPathname);
            _zipStream = new ZipOutputStream(fsOut);
            _zipStream.SetLevel(9);
            _zipStream.SetComment(Comment);
            _solutionFolder = OptionsGuiData.SolutionPath.GetDirectoryName();
            if (NumberOfProjects > 1)
            {
                _folderOffset = _solutionFolder.Length + (_solutionFolder.EndsWith("\\") ? 0 : 1);
            }
            else
            {
                var projectPath = ProjectFiles.First().GetDirectoryName();
                _folderOffset = projectPath.Length + (projectPath.EndsWith("\\") ? 0 : 1);
            }
        }

        private void initVsixFile()
        {
            var fileName = Path.ChangeExtension(OutPathname, ".vsix");
            var fsOut = File.Create(fileName);
            _zipStream = new ZipOutputStream(fsOut);
            _zipStream.SetLevel(9);
            _solutionFolder = OutPathname.GetDirectoryName();
            _folderOffset = _solutionFolder.Length + (_solutionFolder.EndsWith("\\") ? 0 : 1);
        }

        private void setBaseLen()
        {
            const string startInstallPath = @"C:\Documents and Settings\Administrator\Local Settings\Application Data\Microsoft\VisualStudio\10.0\Extensions\";
            _minInstallPathLength =
                startInstallPath.Length + OptionsGuiData.CompanyName.Length +
                OptionsGuiData.ProductName.Length + OptionsGuiData.Version.Length +
                VsixManifestCreator.TemplatePath.Length + Uri.EscapeUriString(OptionsGuiData.ProjectSubType).Length
                + Path.ChangeExtension(OutPathname, ".vsix").GetFileName().Length + 8;
        }

        #endregion Methods
    }
}