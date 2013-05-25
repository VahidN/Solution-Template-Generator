using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class VSTemplateTemplateContentProjectItem
	{
		[XmlAttribute]
		public string SubType
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

		[XmlAttribute]
		public string TargetFileName
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
	}
}