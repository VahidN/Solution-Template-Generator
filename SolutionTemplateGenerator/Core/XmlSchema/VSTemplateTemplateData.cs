using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class VSTemplateTemplateData
	{
		public NameDescriptionIcon Name
		{
			get;
			set;
		}

		public NameDescriptionIcon Description
		{
			get;
			set;
		}

		public NameDescriptionIcon Icon
		{
			get;
			set;
		}

		public NameDescriptionIcon PreviewImage
		{
			get;
			set;
		}

		public string ProjectType
		{
			get;
			set;
		}

		public string ProjectSubType
		{
			get;
			set;
		}

		public string TemplateID
		{
			get;
			set;
		}

		public string TemplateGroupID
		{
			get;
			set;
		}

		[XmlElement(DataType = "integer")]
		public string SortOrder
		{
			get;
			set;
		}

		public bool CreateNewFolder
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool CreateNewFolderSpecified
		{
			get;
			set;
		}

		public string DefaultName
		{
			get;
			set;
		}

		public bool ProvideDefaultName
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool ProvideDefaultNameSpecified
		{
			get;
			set;
		}

		public bool PromptForSaveOnCreation
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool PromptForSaveOnCreationSpecified
		{
			get;
			set;
		}

		public bool EnableLocationBrowseButton
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool EnableLocationBrowseButtonSpecified
		{
			get;
			set;
		}

		public bool EnableEditOfLocationField
		{
			get;
			set;
		}
		[XmlIgnore]
		public bool EnableEditOfLocationFieldSpecified
		{
			get;
			set;
		}

		public bool Hidden
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool HiddenSpecified
		{
			get;
			set;
		}

		public string LocationFieldMRUPrefix
		{
			get;
			set;
		}

		[XmlElement(DataType = "integer")]
		public string NumberOfParentCategoriesToRollUp
		{
			get;
			set;
		}

		public object CreateInPlace
		{
			get;
			set;
		}

		public object BuildOnLoad
		{
			get;
			set;
		}

		public object ShowByDefault
		{
			get;
			set;
		}

		public VSTemplateTemplateDataLocationField LocationField
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool LocationFieldSpecified
		{
			get;
			set;
		}

		public bool SupportsMasterPage
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool SupportsMasterPageSpecified
		{
			get;
			set;
		}

		public bool SupportsCodeSeparation
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool SupportsCodeSeparationSpecified
		{
			get;
			set;
		}

		public bool SupportsLanguageDropDown
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool SupportsLanguageDropDownSpecified
		{
			get;
			set;
		}

		public VSTemplateTemplateDataRequiredFrameworkVersion RequiredFrameworkVersion
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool RequiredFrameworkVersionSpecified
		{
			get;
			set;
		}

		public VSTemplateTemplateData()
		{
			if (this.Icon == null)
			{
				this.Icon = new NameDescriptionIcon();
			}
			if (this.PreviewImage == null)
			{
				this.PreviewImage = new NameDescriptionIcon();
			}
			if (this.Description == null)
			{
				this.Description = new NameDescriptionIcon();
			}
			if (this.Name == null)
			{
				this.Name = new NameDescriptionIcon();
			}
		}
	}
}