namespace SolutionTemplateGenerator.Core.Preprocessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using SolutionTemplateGenerator.Core.Utils;

    public static class ModifyProjectFile
    {
        public static byte[] Start(string path, string defaultNamespace)
        {
            var projectFile = modifyPackagesPath(path);

            var ext = path.GetExtension();
            var document = XDocument.Load(new StringReader(projectFile));

            document.replaceElementContent("RootNamespace", "$safeprojectname$");
            document.replaceElementContent("AssemblyName", "$safeprojectname$");
            document.replaceElementContent("DocumentationFile", "$safeprojectname$");
            if (ext.Equals(".vbproj", StringComparison.InvariantCultureIgnoreCase))
            {
                document.replaceElementContent("StartupObject", "$safeprojectname$.My.MyApplication");
            }
            else
            {
                document.replaceElementContent("StartupObject", "$safeprojectname$");
            }
            document.replaceElementContent("ProjectGuid", "$guid1$");
            document.replaceElementContent("XapFilename", "$safeprojectname$.xap");
            document.replaceElementContent("SilverlightAppEntry", "$safeprojectname$.App");

            document.modifyIncludes(defaultNamespace);

            using (var ms = new MemoryStream())
            {
                document.Save(ms);
                return ms.ToArray();
            }
        }

        private static string modifyPackagesPath(string path)
        {
            var xmlFile = File.ReadAllText(path);
            return xmlFile.Replace(@">..\packages", @">..\..\packages"); // `packages` folder will be created beside the .sln file at the root
        }

        private static void modifyIncludes(this XDocument document, string defaultNamespace)
        {
            foreach (var xElement in document.Descendants().Where(x => x.Attribute("Include") != null))
            {
                xElement.Attribute("Include").Value =
                    xElement.Attribute("Include").Value.Replace(defaultNamespace, "$saferootprojectname$"); 
                // $safeprojectname$ here is not the first project name.
                // $safeprojectname$ represents the current project name.

                var nameElement = xElement.Descendants().FirstOrDefault(d => d.Name.LocalName == "Name");
                if (nameElement != null && !string.IsNullOrEmpty(nameElement.Value))
                {
                    nameElement.Value = nameElement.Value.Replace(defaultNamespace, "$saferootprojectname$");
                }
            }
        }

        private static void replaceElementContent(this XDocument document, string elementName, string newValue)
        {
            var xElement = document.Descendants().FirstOrDefault(d => d.Name.LocalName == elementName);
            if (xElement != null && !string.IsNullOrEmpty(xElement.Value))
            {
                xElement.Value = newValue;
            }
        }
    }
}