using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class VSTemplateTemplateContent
	{
		[XmlElement("ProjectCollection", typeof(VSTemplateTemplateContentProjectCollection)), XmlElement("ProjectItem", typeof(VSTemplateTemplateContentProjectItem)), XmlElement("Project", typeof(VSTemplateTemplateContentProject)), XmlElement("References", typeof(VSTemplateTemplateContentReferences))]
		public List<object> Items
        {
            get;
            set;
        }

		[XmlArrayItem("CustomParameter", IsNullable = false)]
		public List<VSTemplateTemplateContentCustomParameter> CustomParameters
        {
            get;
            set;
        }

		public VSTemplateTemplateContent()
		{
            if (this.CustomParameters == null)
			{
                this.CustomParameters = new List<VSTemplateTemplateContentCustomParameter>();
			}
            if (this.Items == null)
			{
                this.Items = new List<object>();
			}
		}
	}
}