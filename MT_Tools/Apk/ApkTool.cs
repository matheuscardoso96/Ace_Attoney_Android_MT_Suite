using System.Diagnostics;

namespace MTTools.Apk
{
    public static class ApkTool
    {
        private const string _apkExportPath = "APK\\Exported\\";
        private const string _newApkPath = "APK\\New\\";
        private const string _fileNotFoundMsg = "Arquivo .apk não encontrado.";
        private const string _directoryEmptyError = "O diretorio selecionado está vazio.";
        private const string _apkDecompileError = "Erro ao decompilar apk, verifique se o java está instalado.";
        private static readonly string _apkToolPath = $"{Environment.CurrentDirectory}\\Tools\\apktool.jar";

        public static void DecompileApk(string apkPath, string gameName) 
        {
            if (!File.Exists(apkPath))
                throw new FileNotFoundException(_fileNotFoundMsg);

            if (!Directory.Exists(_apkExportPath))
                Directory.CreateDirectory(_apkExportPath);

            CommandExecute(CreateDecompileCommand(apkPath, $"{_apkExportPath}{gameName}"));
            
            if (!Directory.Exists($"{_apkExportPath}{gameName}"))
                throw new DirectoryNotFoundException(_apkDecompileError);
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
            return $"-jar \"{_apkToolPath}\" -f d \"{apkPath}\" -o \"{destPath}\"";
        }

        private static string CreateCompileCommmand(string apkExportedPath, string apkName) 
        {
            return $"-jar \"{_apkToolPath}\" b {apkExportedPath} -o {_newApkPath}{apkName}.apk";
        }

        private static void CommandExecute(string command)
        {
            Process process = new();
            ProcessStartInfo processInfo = new("java.exe", command);
            process.StartInfo = processInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }
    }
}
