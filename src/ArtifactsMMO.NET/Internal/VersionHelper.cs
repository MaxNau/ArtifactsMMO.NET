using System.Linq;
using System.Reflection;

namespace ArtifactsMMO.NET.Internal
{
    internal static class VersionHelper
    {
        static VersionHelper()
        {
            Version = GetVersion();
        }

        public static string Version { get; }

        private static string GetVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var assemblyVersionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (assemblyVersionAttribute != null)
            {
                return assemblyVersionAttribute.InformationalVersion.Split('+')?.FirstOrDefault();
            }

            return string.Empty;
        }
    }
}
