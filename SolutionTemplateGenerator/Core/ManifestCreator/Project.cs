namespace SolutionTemplateGenerator.Core.ManifestCreator
{
    using System.IO;
    using SolutionTemplateGenerator.Core.Utils;

    public class Project
    {
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

        public string FullPath
        {
            get { return Path.Combine(SolutionFilePath.GetDirectoryName(), RelativePath); }
        }
    }
}