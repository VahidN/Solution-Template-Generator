namespace SolutionTemplateGenerator.Core.ManifestCreator
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using SolutionTemplateGenerator.Core.Preprocessor;
    using SolutionTemplateGenerator.Core.Utils;
    using SolutionTemplateGenerator.Core.XmlSchema;
    using SolutionTemplateGenerator.Models;

    public static class ProjectVSTemplateCreator
    {
        #region Methods (3)

        // Public Methods (1) 

        public static string GetProjectVSTemplate(OptionsGui data, string projectFilePath)
        {
            var regex = new Regex(@"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]");
            var template = new VSTemplate
            {
                Type = "Project",
                Version = "3.0.0"
            };
            template.TemplateData.Name.Value = data.ProductName;
            template.TemplateData.Description.Value = data.ProductDescription;
            template.TemplateData.ProjectType = data.ProjectType;
            template.TemplateData.ProjectSubType = data.ProjectSubType;
            template.TemplateData.SortOrder = "1000";
            template.TemplateData.CreateNewFolderSpecified = true;
            template.TemplateData.CreateNewFolder = true;
            template.TemplateData.DefaultName = regex.Replace(data.ProductName, "");
            template.TemplateData.ProvideDefaultNameSpecified = true;
            template.TemplateData.ProvideDefaultName = true;
            template.TemplateData.LocationFieldSpecified = true;
            template.TemplateData.LocationField = VSTemplateTemplateDataLocationField.Enabled;
            template.TemplateData.EnableLocationBrowseButtonSpecified = true;
            template.TemplateData.EnableLocationBrowseButton = true;
            template.TemplateData.Icon.Value = "__Template_small.png";
            template.TemplateData.PreviewImage.Value = "__Template_large.png";

            var contentProject = new VSTemplateTemplateContentProject
            {
                File = projectFilePath.GetFileName().replaceNamespace(data),
                ReplaceParameters = true,
                ReplaceParametersSpecified = true,
                TargetFileName = projectFilePath.GetFileName().replaceNamespace(data)
            };
            var rootDir = projectFilePath.GetDirectoryName() + "\\";
            addAllFiles(rootDir, rootDir, contentProject, data);
            template.TemplateContent.Items.Add(contentProject);

            return Serializer.Serialize(template);
        }
        // Private Methods (2) 

        private static void addAllFiles(string rootDir, string path, VSTemplateTemplateContentProject contentProject, OptionsGui data)
        {
            var files = Directory.GetFiles(path);
            foreach (var filePath in files)
            {
                var shouldReplace = ModifyFactory.IsCodeFile(filePath) || ModifyFactory.IsProjectFile(filePath);
                var projectItem = new ProjectItem
                {
                    ReplaceParameters = shouldReplace,
                    ReplaceParametersSpecified = shouldReplace,
                    TargetFileName = filePath.GetFileName().replaceNamespace(data),
                    Value = filePath.Replace(rootDir, string.Empty).replaceNamespace(data)
                };

                contentProject.Items.Add(projectItem);
            }

            var folders = Directory.GetDirectories(path);
            foreach (var folder in folders)
            {
                if (folder.EndsWith("bin", StringComparison.InvariantCultureIgnoreCase) ||
                   folder.EndsWith("obj", StringComparison.InvariantCultureIgnoreCase))
                    continue;

                addAllFiles(rootDir, folder, contentProject, data);
            }
        }

        private static string replaceNamespace(this string text, OptionsGui data)
        {
            return text.Replace(data.DefaultNamespace, "$safeprojectname$");
        }

        #endregion Methods
    }
}