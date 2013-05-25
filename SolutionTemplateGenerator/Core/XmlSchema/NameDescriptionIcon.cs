using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlType(Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class NameDescriptionIcon
	{
		[XmlAttribute]
		public string Package
		{
			get;
			set;
		}

		[XmlAttribute]
		public string ID
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
	}
}
