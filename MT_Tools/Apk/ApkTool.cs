using System.Diagnostics;

namespace MTTools.Apk
{
    public static class ApkTool
    {
        private const string _apkExportPath = "APK\\Exported\\";
        private const string _newApkPath = "APK\\New\\";
        private const string _fileNotFoundMsg = "Arquivo .apk não encontrado.";
        private const string _directoryEmptyError = "Arquivo .apk não encontrado.";
        private static readonly string _apkToolPath = $"{Environment.CurrentDirectory}Tools\\apktool.jar ";

        public static void DecompileApk(string apkPath, string destPath) 
        {
            if (!File.Exists(apkPath))
                throw new FileNotFoundException(_fileNotFoundMsg);

            CommandExecute(CreateDecompileCommand(apkPath, destPath));
        }

        public static void CompileApk(string apkExportedPath, string apkName)
        {
            if (IsDirectoryEmpty(apkExportedPath))
                throw new Exception(_directoryEmptyError);

            CommandExecute(CreateCompileCommmand(apkExportedPath, apkName));
        }

        private static bool IsDirectoryEmpty(string path) 
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private static string CreateDecompileCommand(string apkPath, string destPath) 
        {
            return $"java -jar {_apkToolPath} -f d \"{apkPath}\" -o \"{_apkExportPath}{destPath}\"";
        }

        private static string CreateCompileCommmand(string apkExportedPath, string apkName) 
        {
            return $"apktool b {_apkToolPath} -o {_newApkPath}{apkName}.apk";
        }

        private static void CommandExecute(string command)
        {
            Process process = new();
            ProcessStartInfo processInfo = new("cmd.exe", command);
            process.StartInfo = processInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }
    }
}
