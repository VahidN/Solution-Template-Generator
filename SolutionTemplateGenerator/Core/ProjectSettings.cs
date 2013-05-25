using System.IO;
using System.Windows.Forms;
using SolutionTemplateGenerator.Core.Utils;
using SolutionTemplateGenerator.Models;

namespace SolutionTemplateGenerator.Core
{
    public static class ProjectSettings
    {
        private static readonly string XmlPath = Path.Combine(Application.StartupPath, "settings.xml");

        public static void SaveSettings(OptionsGui data)
        {
            var xml = Serializer.Serialize(data);
            File.WriteAllText(XmlPath, xml);
        }

        public static OptionsGui LoadSettings()
        {
            if (!File.Exists(XmlPath))
                return new OptionsGui();

            var xml = File.ReadAllText(XmlPath);
            return Serializer.Deserialize<OptionsGui>(xml);
        }
    }
}