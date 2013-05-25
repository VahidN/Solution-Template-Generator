using System.CodeDom.Compiler;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vsx-schema/2010")]
	public class VsixIdentifierIsolatedShell
	{
		[XmlAttribute]
		public string Version
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