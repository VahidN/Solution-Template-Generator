using System.Diagnostics;
using System.IO;
using System.Linq;
using SolutionTemplateGenerator.Models;

namespace SolutionTemplateGenerator.Core
{
    using SolutionTemplateGenerator.Core.ManifestCreator;

    public static class TemplateGeneratorFactory
    {
        public static void Start(OptionsGui data)
        {
            var projects = SolutionFileParser.GetSolutionProjects(data.SolutionPath);
            if (!projects.Any())
                return;

            if (!Directory.Exists(data.OutputFolder))
                Directory.CreateDirectory(data.OutputFolder);

            new ZipSolution
            {
                Comment = "Created by SolutionTemplateGenerator",
                IncludeSubfolders = true,
                OptionsGuiData = data,
                OutPathname = Path.Combine(data.OutputFolder, data.ProductName + ".zip"),
                NumberOfProjects = projects.Count,
                ProjectFiles = projects.Select(x => x.FullPath).ToList()
            }.ZipFolder();

            Process.Start(data.OutputFolder);
        }
    }
}