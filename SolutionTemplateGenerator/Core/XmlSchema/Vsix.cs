using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), XmlRoot(Namespace = "http://schemas.microsoft.com/developer/vsx-schema/2010", IsNullable = false), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vsx-schema/2010")]
	public class Vsix
	{		
		public VsixIdentifier Identifier
		{
			get;
			set;
		}

		[XmlArrayItem("Reference", IsNullable = false)]
		public List<VsixReference> References
        {
            get;
            set;
        }

		public VsixContent Content
		{
			get;
			set;
		}

		[XmlAttribute]
		public string Version
		{
			get;
			set;
		}

		public Vsix()
		{
			if (this.Content == null)
			{
				this.Content = new VsixContent();
			}
            if (this.References == null)
			{
                this.References = new List<VsixReference>();
			}
			if (this.Identifier == null)
			{
				this.Identifier = new VsixIdentifier();
			}
		}
	}
}