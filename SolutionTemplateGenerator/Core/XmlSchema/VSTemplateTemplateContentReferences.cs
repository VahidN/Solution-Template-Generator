using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class VSTemplateTemplateContentReferences
	{
		public VSTemplateTemplateContentReferencesReference Reference
		{
			get;
			set;
		}

		public VSTemplateTemplateContentReferences()
		{
			if (this.Reference == null)
			{
				this.Reference = new VSTemplateTemplateContentReferencesReference();
			}
		}
	}
}