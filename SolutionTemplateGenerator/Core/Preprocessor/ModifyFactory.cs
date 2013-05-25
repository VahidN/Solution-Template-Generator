namespace SolutionTemplateGenerator.Core.Preprocessor
{
    using System.IO;

    using SolutionTemplateGenerator.Core.Utils;

    public static class ModifyFactory
    {
        public static bool IsCodeFile(string path)
        {
            switch (path.GetExtension().ToLower())
            {
                case ".cs":
                case ".vb":
                case ".xaml":
                case ".aspx":
                case ".asax":
                case ".master":
                case ".cshtml":
                case ".vbhtml":
                    return true;
            }

            return false;
        }

        public static bool IsProjectFile(string path)
        {
            switch (path.GetExtension().ToLower())
            {
                case ".csproj":
                case ".vbproj":
                    return true;
            }

            return false;
        }

        public static byte[] ProcessFile(string path, string defaultNamespace)
        {
            if (IsCodeFile(path))
                return ModifyCodeFile.Start(path, defaultNamespace);

            if (IsProjectFile(path))
                return ModifyProjectFile.Start(path, defaultNamespace);

            return File.ReadAllBytes(path);
        }
    }
}