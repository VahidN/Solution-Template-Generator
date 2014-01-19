namespace SolutionTemplateGenerator.Core.ManifestCreator
{
    using System.IO;
    using System.Text.RegularExpressions;
    using SolutionTemplateGenerator.Core.Utils;

    public class Project
    {
        private static readonly Regex AssemblyVersionRegex = new Regex("\\s*[\\[<]\\s*[Aa]ssembly\\s*:\\s*(System.Reflection.)?AssemblyVersion\\s*\\(\\s*\"(?<ValueToBeReplaced>.*?)(\"\\s*\\)\\s*[\\]>])", RegexOptions.Singleline | RegexOptions.Compiled);

        public string ProjectGuid { get; set; }

        public string ProjectTypeGuid { get; set; }

        public string ProjectName { get; set; }

        public string RelativePath { get; set; }

        public string SolutionFilePath { get; set; }

        public string ProjectTypeName
        {
            get
            {
                string name;
                KnownProjectTypeGuid.ProjectTypes.TryGetValue(ProjectTypeGuid, out name);
                return name;
            }
        }

        public string Version
        {
            get
            {
                return getVersion();
            }
        }

        private string getVersion()
        {
            var version = "1.0";
            var assemblyInfoFile = Path.Combine(Path.GetDirectoryName(FullPath), "Properties\\AssemblyInfo.cs");
            if (!File.Exists(assemblyInfoFile))
                return version;

            var versionMatches = AssemblyVersionRegex.Matches(File.ReadAllText(assemblyInfoFile));
            foreach (Match match in versionMatches)
            {
                version = match.Groups["ValueToBeReplaced"].Value;
            }
            return version;
        }

        public string FullPath
        {
            get { return Path.Combine(SolutionFilePath.GetDirectoryName(), RelativePath); }
        }
    }
}