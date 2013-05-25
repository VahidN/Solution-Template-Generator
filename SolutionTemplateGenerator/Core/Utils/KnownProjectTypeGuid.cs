namespace SolutionTemplateGenerator.Core.Utils
{
    using System.Collections.Generic;

    public static class KnownProjectTypeGuid
    {
        public static readonly IDictionary<string, string> ProjectTypes = new Dictionary<string, string>
        {
          { "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}", "VisualBasic" },
          { "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}", "CSharp" },
          { "{E6FDF86B-F3D1-11D4-8576-0002A516ECE8}", "JSharp" },
          { "{F2A71F9B-5D33-465A-A702-920D77279786}", "FSharp" },
          { "{2150E333-8FDC-42A3-9474-1A3956D46DE8}", "SolutionFolder" },
          { "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}", "VisualC" },
          { "{54435603-DBB4-11D2-8724-00A0C9A8B90C}", "Setup" },
          { "{E24C65DC-7377-472B-9ABA-BC803B73C61A}", "WebProject" }
       };
    }
}