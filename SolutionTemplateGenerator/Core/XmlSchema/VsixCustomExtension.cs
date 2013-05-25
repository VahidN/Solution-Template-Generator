using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vsx-schema/2010")]
	public class VsixCustomExtension
	{
		[XmlAttribute]
		public string Type
		{
			get;
			set;
		}

		[XmlText]
		public string Value
		{
			get;
			set;
		}

		[XmlAnyAttribute]
		public List<XmlAttribute> AnyAttr
        {
            get;
            set;
        }

		public VsixCustomExtension()
		{
            if (this.AnyAttr == null)
			{
                this.AnyAttr = new List<XmlAttribute>();
			}
		}
	}
}