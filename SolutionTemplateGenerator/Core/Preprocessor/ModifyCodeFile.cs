namespace SolutionTemplateGenerator.Core.Preprocessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class ModifyCodeFile
    {
        #region Fields (5)

        private static readonly Regex AssemblyCompanyRegex = new Regex("\\s*[\\[<]\\s*[Aa]ssembly\\s*:\\s*(System.Reflection.)?AssemblyCompany\\s*\\(\\s*\"(?<ValueToBeReplaced>.*?)(\"\\s*\\)\\s*[\\]>])", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex AssemblyGuidRegex = new Regex("\\s*[\\[<]\\s*[Aa]ssembly\\s*:\\s*(System.Runtime.InteropServices.)?Guid\\s*\\(\\s*\"(?<ValueToBeReplaced>.*?)(\"\\s*\\)\\s*[\\]>])", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex AssemblyProductRegex = new Regex("\\s*[\\[<]\\s*[Aa]ssembly\\s*:\\s*(System.Reflection.)?AssemblyProduct\\s*\\(\\s*\"(?<ValueToBeReplaced>.*?)(\"\\s*\\)\\s*[\\]>])", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex AssemblyTitleRegex = new Regex("\\s*[\\[<]\\s*[Aa]ssembly\\s*:\\s*(System.Reflection.)?AssemblyTitle\\s*\\(\\s*\"(?<ValueToBeReplaced>.*?)(\"\\s*\\)\\s*[\\]>])", RegexOptions.Singleline | RegexOptions.Compiled);

        #endregion Fields

        #region Methods (3)

        // Public Methods (1) 

        public static byte[] Start(string path, string defaultNamespace)
        {
            string originalText = File.ReadAllText(path);

            if (!string.IsNullOrEmpty(defaultNamespace))
            {
                const string replaceText = "$saferootprojectname$";
                originalText = replaceWord(originalText, defaultNamespace, replaceText);
            }

            originalText = applyRegex(AssemblyTitleRegex, originalText, "$projectname$");
            originalText = applyRegex(AssemblyCompanyRegex, originalText, "$registeredorganization$");
            originalText = applyRegex(AssemblyProductRegex, originalText, "$projectname$");
            originalText = applyRegex(AssemblyGuidRegex, originalText, "$guid1$");

            return Encoding.UTF8.GetBytes(originalText);
        }
        // Private Methods (2) 

        private static string applyRegex(Regex regex, string content, string newValue)
        {
            foreach (Match match in regex.Matches(content))
            {
                Group group = match.Groups["ValueToBeReplaced"];
                content = content.Remove(group.Index, group.Length);
                content = content.Insert(group.Index, newValue);
            }
            return content;
        }

        private static string replaceWord(string text, string findText, string replaceText)
        {
            int startIndex = 0;
            while (true)
            {
                int idx;
                do
                {
                    do
                    {
                        idx = text.IndexOf(findText, startIndex, StringComparison.Ordinal);
                        if (idx == -1)
                        {
                            return text;
                        }
                        startIndex = idx + findText.Length;
                    }
                    while (((idx != 0) && !char.IsWhiteSpace(text[idx - 1])) && ("\\/.,;-()<>{}'\"~!+=`@#$%^&*[]|:?".IndexOf(text[idx - 1]) == -1));
                }
                while (((text.Length != (idx + findText.Length)) && !char.IsWhiteSpace(text[idx + findText.Length])) && ("\\/.,;-()<>{}'\"~!+=`@#$%^&*[]|:?".IndexOf(text[idx + findText.Length]) == -1));
                text = text.Remove(idx, findText.Length).Insert(idx, replaceText);
                startIndex = idx + replaceText.Length;
            }
        }

        #endregion Methods
    }
}