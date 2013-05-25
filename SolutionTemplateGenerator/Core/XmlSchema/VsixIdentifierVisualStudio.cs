using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace SolutionTemplateGenerator.Core.XmlSchema
{
    [GeneratedCode("System.Xml", "2.0.50727.4927"), XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/vsx-schema/2010")]
    public class VsixIdentifierVisualStudio
    {
        [XmlAttribute]
        public string Version
        {
            get;
            set;
        }

        [XmlElement("Edition")]
        public List<string> Edition
        {
            get;
            set;
        }

        public VsixIdentifierVisualStudio()
        {
            if (this.Edition == null)
            {
                this.Edition = new List<string>();
            }
        }
    }
}