namespace SolutionTemplateGenerator.Core.ManifestCreator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public static class SolutionFileParser
    {
        #region Fields (2)

        private const string Pattern = "^Project\\(\"(?<PROJECTTYPEGUID>.*)\"\\)\\s*=\\s*\"(?<PROJECTNAME>.*)\"\\s*,\\s*\"(?<RELATIVEPATH>.*)\"\\s*,\\s*\"(?<PROJECTGUID>.*)\"$";
        private static readonly Regex ProjectRegex = new Regex(Pattern, RegexOptions.Compiled);

        #endregion Fields

        #region Methods (1)

        // Public Methods (1) 

        public static IList<Project> GetSolutionProjects(string path)
        {
            var results = new List<Project>();

            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (!line.StartsWith("Project(", StringComparison.InvariantCultureIgnoreCase))
                    continue;

                var match = ProjectRegex.Match(line);
                if (!match.Success)
                    continue;

                results.Add(new Project
                {
                    ProjectGuid = match.Groups["PROJECTGUID"].Value.Trim(),
                    ProjectName = match.Groups["PROJECTNAME"].Value.Trim(),
                    ProjectTypeGuid = match.Groups["PROJECTTYPEGUID"].Value.Trim(),
                    RelativePath = match.Groups["RELATIVEPATH"].Value.Trim(),
                    SolutionFilePath = path
                });
            }

            return results;
        }

        #endregion Methods
    }
}