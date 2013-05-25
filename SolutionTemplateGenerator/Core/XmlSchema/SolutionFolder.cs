using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlRoot(Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005", IsNullable = false), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class SolutionFolder
	{
		[XmlAttribute]
		public string Name
		{
			get;
			set;
		}

        [XmlElement("ProjectTemplateLink", typeof(ProjectTemplateLink)), XmlElement("SolutionFolder", typeof(SolutionFolder))]
        public List<object> Items { get; set; }		

		public SolutionFolder()
		{
            if (this.Items == null)
			{
                this.Items = new List<object>();
			}
		}
	}
}