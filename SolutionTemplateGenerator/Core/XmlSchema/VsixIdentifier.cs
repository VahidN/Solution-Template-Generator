using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vsx-schema/2010")]
	public class VsixIdentifier
	{
		public string Name
		{
			get;
			set;
		}

		public string Author
		{
			get;
			set;
		}

		public string Version
		{
			get;
			set;
		}
		public string Description
		{
			get;
			set;
		}

		public ushort Locale
		{
			get;
			set;
		}

		public string MoreInfoUrl
		{
			get;
			set;
		}

		public string License
		{
			get;
			set;
		}

		public string GettingStartedGuide
		{
			get;
			set;
		}

		public string Icon
		{
			get;
			set;
		}

		public string PreviewImage
		{
			get;
			set;
		}

		public bool InstalledByMsi
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool InstalledByMsiSpecified
		{
			get;
			set;
		}

		[XmlArrayItem("VisualStudio", typeof(VsixIdentifierVisualStudio), IsNullable = false), XmlArrayItem("IsolatedShell", typeof(VsixIdentifierIsolatedShell), IsNullable = false)]
		public List<object> SupportedProducts
        {
            get;
            set;
        }

		public VsixIdentifierSupportedFrameworkRuntimeEdition SupportedFrameworkRuntimeEdition
		{
			get;
			set;
		}

		public bool SystemComponent
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool SystemComponentSpecified
		{
			get;
			set;
		}

		public bool AllUsers
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool AllUsersSpecified
		{
			get;
			set;
		}

		[XmlAttribute]
		public string Id
		{
			get;
			set;
		}

		public VsixIdentifier()
		{
			if (this.SupportedFrameworkRuntimeEdition == null)
			{
				this.SupportedFrameworkRuntimeEdition = new VsixIdentifierSupportedFrameworkRuntimeEdition();
			}
			if (this.SupportedProducts == null)
			{
                this.SupportedProducts = new List<object>();
			}
		}
	}
}