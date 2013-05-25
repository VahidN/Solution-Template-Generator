using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class VSTemplateWizardExtension
	{
		[XmlElement("Assembly", Type = typeof(string))]
		public List<object> Assembly
        {
            get;
            set;
        }

		[XmlElement("FullClassName", Type = typeof(string))]
		public List<object> FullClassName
        {
            get;
            set;
        }

		public VSTemplateWizardExtension()
		{
			if (this.FullClassName == null)
			{
				this.FullClassName = new List<object>();
			}
			if (this.Assembly == null)
			{
				this.Assembly = new List<object>();
			}
		}
	}
}