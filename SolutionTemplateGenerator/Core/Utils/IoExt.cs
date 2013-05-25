using System;

namespace SolutionTemplateGenerator.Core.Utils
{
    using System.IO;

    public static class IoExt
    {
        public static string GetFileName(this string path)
        {
            var name = Path.GetFileName(path);
            if(string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException(string.Format("Couldn't extract name of the `{0}`", path));

            return name;
        }

        public static string GetDirectoryName(this string path)
        {
            var name = Path.GetDirectoryName(path);
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException(string.Format("Couldn't extract DirectoryName of the `{0}`", path));

            return name;
        }

        public static string GetExtension(this string path)
        {
            var name = Path.GetExtension(path);
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException(string.Format("Couldn't extract extension of the `{0}`", path));

            return name;
        }
    }
}