namespace SolutionTemplateGenerator.Core.ManifestCreator
{
    using System;
    using System.Collections.Generic;
    using SolutionTemplateGenerator.Core.Utils;
    using SolutionTemplateGenerator.Core.XmlSchema;
    using SolutionTemplateGenerator.Models;

    public static class VsixManifestCreator
    {
        #region Fields (1)

        public const string TemplatePath = "Data";

        #endregion Fields

        #region Methods (1)

        // Public Methods (1)

        /// <summary>
        /// Creates extension.vsixmanifest file's content.
        /// </summary>
        public static string GetVsixManifest(OptionsGui data)
        {
            var vsix = new Vsix
                {
                    Version = "1.0.0",
                    Identifier =
                        {
                            Id = data.ProductName + "." + Guid.NewGuid(),
                            Name = data.ProductName,
                            Version = data.Version,
                            Author = data.CompanyName
                        }
                };

            if (string.IsNullOrEmpty(vsix.Identifier.Author))
            {
                vsix.Identifier.Author = "Author";
            }

            vsix.Identifier.Description = data.ProductDescription;
            vsix.Identifier.InstalledByMsiSpecified = true;
            vsix.Identifier.InstalledByMsi = false;
            vsix.Identifier.Locale = 1033;

            vsix.Identifier.SupportedFrameworkRuntimeEdition.MaxVersion = data.ShouldSupportVS2012 ? "4.5" : "4.0";
            vsix.Identifier.SupportedFrameworkRuntimeEdition.MinVersion = "4.0";

            vsix.Identifier.SupportedProducts = new List<object>();
            if (data.ShouldSupportVS2010)
            {
                vsix.Identifier.SupportedProducts.Add(new VsixIdentifierVisualStudio
                {
                    Version = "10.0",
                    Edition = new List<string> { "Ultimate", "Premium", "Pro", "Express_All" }
                });
            }

            if (data.ShouldSupportVS2012)
            {
                vsix.Identifier.SupportedProducts.Add(new VsixIdentifierVisualStudio
                {
                    Version = "11.0",
                    Edition = new List<string> { "Ultimate", "Premium", "Pro", "Express_All" }
                });
            }

            if (data.ShouldSupportVS2013)
            {
                vsix.Identifier.SupportedProducts.Add(new VsixIdentifierVisualStudio
                {
                    Version = "12.0",
                    Edition = new List<string> { "Ultimate", "Premium", "Pro", "Express_All" }
                });
            }

            if (data.ShouldSupportVS2015)
            {
                vsix.Identifier.SupportedProducts.Add(new VsixIdentifierVisualStudio
                {
                    Version = "14.0",
                    Edition = new List<string> { "Ultimate", "Premium", "Pro", "Express_All" }
                });
            }


            if (!string.IsNullOrEmpty(data.GettingStartedGuideUrl))
            {
                vsix.Identifier.GettingStartedGuide = Uri.EscapeUriString(data.GettingStartedGuideUrl);
            }

            vsix.Identifier.PreviewImage = "__Template_large.png";
            vsix.Identifier.Icon = "__Template_small.png";

            vsix.Identifier.License = Uri.EscapeUriString(!string.IsNullOrEmpty(data.LicenseFilePath) ?
                data.LicenseFilePath.GetFileName() : "MIT.txt");

            var list = new List<ItemsChoiceType> { ItemsChoiceType.ProjectTemplate, ItemsChoiceType.Assembly };
            vsix.Content.ItemsElementName = list.ToArray();

            var list2 = new List<object> { TemplatePath };
            list2.Add(new VsixAssembly
            {
                AssemblyName = typeof(SafeRootProjectWizard.ChildWizard).Assembly.FullName,
                Value = typeof(SafeRootProjectWizard.ChildWizard).Assembly.Location.GetFileName()
            });
            vsix.Content.Items = list2.ToArray();

            return Serializer.Serialize(vsix);
        }

        #endregion Methods
    }
}