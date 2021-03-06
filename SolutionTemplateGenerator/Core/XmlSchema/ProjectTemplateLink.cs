using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlRoot(Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005", IsNullable = false), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class ProjectTemplateLink
	{
		[XmlAttribute]
		public string ProjectName
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

        [XmlAttribute]
        public bool ReplaceParameters { set; get; }
	}
}