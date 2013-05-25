using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class VSTemplateTemplateContentProject
	{
		[XmlAttribute]
		public string File
		{
			get;
			set;
		}

		[XmlAttribute]
		public string TargetFileName
		{
			get;
			set;
		}

		[XmlAttribute]
		public bool ReplaceParameters
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool ReplaceParametersSpecified
		{
			get;
			set;
		}

		[XmlElement("Folder", typeof(Folder)), XmlElement("ProjectItem", typeof(ProjectItem))]
		public List<object> Items
        {
            get;
            set;
        }

		public VSTemplateTemplateContentProject()
		{
            if (this.Items == null)
			{
                this.Items = new List<object>();
			}
		}
	}
}