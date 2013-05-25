using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlRoot(Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005", IsNullable = false), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class ProjectItem
	{
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

		[XmlAttribute]
		public bool OpenInEditor
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool OpenInEditorSpecified
		{
			get;
			set;
		}

		[XmlAttribute]
		public int OpenOrder
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool OpenOrderSpecified
		{
			get;
			set;
		}

		[XmlAttribute]
		public bool OpenInWebBrowser
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool OpenInWebBrowserSpecified
		{
			get;
			set;
		}

		[XmlAttribute]
		public bool OpenInHelpBrowser
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool OpenInHelpBrowserSpecified
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