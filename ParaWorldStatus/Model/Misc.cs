using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ParaWorldStatus.Model
{
    public static class Misc
    {
        public static int ParseUint(this string txt)
        {
            return int.TryParse(txt, out var value) && value >= 0 ? value : 0;
        }

        /// <summary>
        /// The Unix Epoch date (1970-1-1 00:00:00).
        /// </summary>
        public static DateTime UnixEpoch { get; } = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long GetUnixTimestampSeconds(this DateTime time)
        {
            var univDateTime = time.ToUniversalTime();
            return (long)(univDateTime - UnixEpoch).TotalSeconds;
        }

        public static Stream OpenResourceStream(Assembly assembly, string resource)
        {
            var assemblyName = assembly.GetName().Name;
            var stream = assembly.GetManifestResourceStream($"{assemblyName}.{resource}");
            if (stream == null)
            {
                throw new FileNotFoundException($"{resource} was not found");
            }
            return stream;
        }

    }
}
