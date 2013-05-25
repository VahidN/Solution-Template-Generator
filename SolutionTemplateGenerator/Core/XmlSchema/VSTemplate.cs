using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

//Note: Don't change the order of properties here, otherwise vs.net won't recognize it!!
namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlRoot(Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005", IsNullable = false), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class VSTemplate
	{
		public VSTemplateTemplateData TemplateData
		{
			get;
			set;
		}

		public VSTemplateTemplateContent TemplateContent
		{
			get;
			set;
		}

		[XmlAttribute]
		public string Type
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

		[XmlElement("WizardExtension")]
		public List<VSTemplateWizardExtension> WizardExtension
        {
            get;
            set;
        }

		[XmlElement("WizardData")]
		public List<VSTemplateWizardData> WizardData
        {
            get;
            set;
        }

		public VSTemplate()
		{
			if (this.WizardData == null)
			{
				this.WizardData = new List<VSTemplateWizardData>();
			}
			if (this.WizardExtension == null)
			{
				this.WizardExtension = new List<VSTemplateWizardExtension>();
			}
			if (this.TemplateContent == null)
			{
				this.TemplateContent = new VSTemplateTemplateContent();
			}
			if (this.TemplateData == null)
			{
				this.TemplateData = new VSTemplateTemplateData();
			}
		}
	}
}