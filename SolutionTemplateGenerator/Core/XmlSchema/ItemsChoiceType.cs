using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), XmlType(Namespace = "http://schemas.microsoft.com/developer/vsx-schema/2010", IncludeInSchema = false)]
	public enum ItemsChoiceType
	{
		Assembly,
		CustomExtension,
		ItemTemplate,
		MefComponent,
		ProjectTemplate,
		ToolboxControl,
		VsPackage
	}
}
