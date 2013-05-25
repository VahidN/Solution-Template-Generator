using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class VSTemplateWizardData
	{
		[XmlAttribute]
		public string Name
		{
			get;
			set;
		}

		[XmlAnyElement]
		public List<XmlElement> Any
        {
            get;
            set;
        }

		public VSTemplateWizardData()
		{
            if (this.Any == null)
			{
                this.Any = new List<XmlElement>();
			}
		}
	}
}