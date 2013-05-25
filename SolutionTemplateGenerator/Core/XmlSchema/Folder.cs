using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
	[GeneratedCode("System.Xml", "2.0.50727.4927"), DebuggerStepThrough, XmlRoot(Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005", IsNullable = false), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vstemplate/2005")]
	public class Folder
	{
	    [XmlAttribute]
		public string Name
		{
			get;
			set;
		}

		[XmlAttribute]
		public string TargetFolderName
		{
			get;
			set;
		}

	    [XmlElement("ProjectItem", typeof(ProjectItem)), XmlElement("Folder", typeof(Folder))]
	    public List<object> Items { get; set; }

	    public Folder()
		{
			if (this.Items == null)
			{
				this.Items = new List<object>();
			}
		}
	}
}