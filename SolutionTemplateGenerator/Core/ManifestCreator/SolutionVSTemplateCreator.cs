namespace SolutionTemplateGenerator.Core.ManifestCreator
{
    using SolutionTemplateGenerator.Core.Utils;
    using SolutionTemplateGenerator.Core.XmlSchema;
    using SolutionTemplateGenerator.Models;

    public static class SolutionVSTemplateCreator
    {
        public static string GetSolutionVSTemplate(OptionsGui data)
        {
            var template = new VSTemplate { Version = "3.0.0", Type = "ProjectGroup" };
            template.TemplateData.Name.Value = data.ProductName;
            template.TemplateData.Description.Value = data.ProductDescription;
            template.TemplateData.ProjectType = data.ProjectType;
            template.TemplateData.ProjectSubType = data.ProjectSubType;
            template.TemplateData.SortOrder = "1000";
            template.TemplateData.CreateNewFolderSpecified = true;
            template.TemplateData.CreateNewFolder = true;
            template.TemplateData.DefaultName = data.ProductName;
            template.TemplateData.ProvideDefaultNameSpecified = true;
            template.TemplateData.ProvideDefaultName = true;
            template.TemplateData.LocationFieldSpecified = true;
            template.TemplateData.LocationField = VSTemplateTemplateDataLocationField.Enabled;
            template.TemplateData.EnableLocationBrowseButtonSpecified = true;
            template.TemplateData.EnableLocationBrowseButton = true;
            template.TemplateData.Icon.Value = "__Template_small.png";
            template.TemplateData.PreviewImage.Value = "__Template_large.png";

            var projectCollection = new VSTemplateTemplateContentProjectCollection();

            var projects = SolutionFileParser.GetSolutionProjects(data.SolutionPath);            
            foreach (var project in projects)
            {
                var name = project.ProjectName.Replace(data.DefaultNamespace, "$safeprojectname$");
                var link = new ProjectTemplateLink
                {
                    ProjectName = name,
                    Value = string.Format("{0}\\MyTemplate.vstemplate", name),
                    ReplaceParameters = true
                };
               projectCollection.Items.Add(link);
            }

            template.TemplateContent.Items.Add(projectCollection);

            return Serializer.Serialize(template);
        }
    }
}