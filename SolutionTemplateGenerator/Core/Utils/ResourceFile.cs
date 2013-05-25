using System;
using System.Reflection;

namespace SolutionTemplateGenerator.Core.Utils
{
    public static class ResourceFile
    {
        public static byte[] GetInputFile(string filename)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            using (var stream = thisAssembly.GetManifestResourceStream(filename))
            {
                if (stream == null)
                    throw new ArgumentException("Resource NotFound: " + filename);

                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                return bytes;
            }
        }
    }
}