using System.CodeDom.Compiler;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vsx-schema/2010")]
	public class VsixContent
	{		
		[XmlChoiceIdentifier("ItemsElementName"), XmlElement("CustomExtension", typeof(VsixCustomExtension)), XmlElement("ItemTemplate", typeof(string)), XmlElement("Assembly", typeof(VsixAssembly)), XmlElement("MefComponent", typeof(string)), XmlElement("ToolboxControl", typeof(string)), XmlElement("ProjectTemplate", typeof(string)), XmlElement("VsPackage", typeof(string))]
		public object[] Items
        {
            get;
            set;
        }

		[XmlElement("ItemsElementName"), XmlIgnore]
		public ItemsChoiceType[] ItemsElementName
        {
            get;
            set;
        }
	}
}