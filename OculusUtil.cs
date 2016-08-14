using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OculusSpecsPatcher
{
    public static class OculusUtil
    {
        private const string OculusBaseVarName = @"OculusBase";
        private const string OculusHomeRelativePath = @"Support\oculus-home";
        
        public static DirectoryInfo GetOculusBaseDirectory()
        {
            string oculusBasePath = Environment.GetEnvironmentVariable(OculusBaseVarName);
            if (oculusBasePath == null)
                return null;

            return Directory.Exists(oculusBasePath) ? new DirectoryInfo(oculusBasePath) : null;
        }

        public static DirectoryInfo GetOculusHomeDir()
        {
            var baseDir = GetOculusBaseDirectory();
            if (baseDir == null)
                return null;

            var clientPath = Path.Combine(baseDir.FullName, OculusHomeRelativePath);
            return Directory.Exists(clientPath) ? new DirectoryInfo(clientPath) : null;
        }
    }
}
