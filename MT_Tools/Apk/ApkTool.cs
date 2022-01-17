using System.Diagnostics;

namespace MTTools.Apk
{
    public static class ApkTool
    {
        private static readonly string  _apkExportPath = $"{Environment.CurrentDirectory}\\APK\\Exported\\";
        private static readonly string _newApkPath = $"{Environment.CurrentDirectory}\\APK\\New\\";
        private const string _fileNotFoundMsg = "Arquivo .apk não encontrado.";
        
        private const string _directoryEmptyErrorMsg = "O diretorio selecionado está vazio.";
        
        private const string _apkDecompileError = "Erro ao decompilar apk, verifique se o java está instalado.";
        
        private const string _apkCompileSuccessMsg = "I: Built apk";
        private const string _apkCompileError = "Erro ao compilar apk, verifique se o java está instalado.";
        
        private const string _jarsignerSuccessMsg = "jar signed";
        private const string _jarsignerErrorMsg = "Falha ao assinar apk, verifique se o programa jarsigner está na pasta tools.";
        
        private const string _zipalignSuccessMsg = "Verification succesful";
        private const string _zipalignErrorMsg = "Falha ao ultilizar o ZipAlign, verifique se o programa ZipAlign está na pasta tools.";

        private static readonly string _apkToolPath = $"{Environment.CurrentDirectory}\\Tools\\apktool.jar";
        private static readonly string _jarsignerPath = $"{Environment.CurrentDirectory}\\Tools\\jarsigner.exe";
        private static readonly string _zipalignPath = $"{Environment.CurrentDirectory}\\Tools\\zipalign.exe";
        private static readonly string _keystorePath = $"{Environment.CurrentDirectory}\\Tools\\key.keystore";

        public static void DecompileApk(string apkPath, string gameName) 
        {
            if (!File.Exists(apkPath))
                throw new FileNotFoundException(_fileNotFoundMsg);

            _ = Directory.CreateDirectory(_apkExportPath);

            _ = CommandExecute("java.exe", CreateDecompileCommand(apkPath, $"{_apkExportPath}{gameName}"));
            
            if (!Directory.Exists($"{_apkExportPath}{gameName}"))
                throw new DirectoryNotFoundException(_apkDecompileError);
        }

        public static void CompileApk(string decompiledApkPath, string apkName)
        {
            string path = $"{Environment.CurrentDirectory}\\{decompiledApkPath}";

            if (IsDirectoryEmpty(path))
                throw new Exception(_directoryEmptyErrorMsg);

            _ = Directory.CreateDirectory(_newApkPath);
           
           var result = CommandExecute("java.exe", CreateCompileCommmand(path));

            if (!result.Contains(_apkCompileSuccessMsg))
                throw new FileNotFoundException(_apkCompileError);

            var apkNewPath = Directory.GetFiles($"{path}\\dist", "*.apk").First();         
            
            SignApk(apkNewPath);
            ZipAlignApk(apkNewPath, apkNewPath.Replace(".apk","_signed.apk"));
            
            File.Delete(apkNewPath);
            File.Move(apkNewPath.Replace(".apk", "_signed.apk"), $"{_newApkPath}{apkName}_{DateTime.Now:dd-MM-yyyy-HH-mm-ss}.apk");        
        }

        private static void SignApk(string apkPath) 
        {
           var result = CommandExecute(_jarsignerPath, CreateSignApkCommmand(apkPath));

            if (!result.Contains(_jarsignerSuccessMsg))
               throw new Exception(_jarsignerErrorMsg);
        }

        private static void ZipAlignApk(string apkPath, string signedApkPath)
        {
            var result = CommandExecute(_zipalignPath, CreateZipAlignCommmand(apkPath, signedApkPath));

            if (!result.Contains(_zipalignSuccessMsg))
                throw new Exception(_zipalignErrorMsg);
        }

        private static bool IsDirectoryEmpty(string path) 
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }


        private static string CreateDecompileCommand(string apkPath, string destPath) 
        {
            return $"-jar \"{_apkToolPath}\" -f d \"{apkPath}\" -o \"{destPath}\"";
        }

        private static string CreateCompileCommmand(string apkExportedPath) 
        {
            return $"-jar \"{_apkToolPath}\" b \"{apkExportedPath}\"";
        }

        private static string CreateSignApkCommmand(string apkPath)
        {
            return $" -sigalg SHA1withRSA -digestalg SHA1 -keystore \"{_keystorePath}\" \"{apkPath}\" capcom -storepass capcom2022";
        }

        private static string CreateZipAlignCommmand(string apkPath, string signedApkPath)
        {
            return $" -v 4 \"{apkPath}\" \"{signedApkPath}\"";
        }

        private static string CommandExecute(string program,string command)
        {
            Process process = new();
            ProcessStartInfo processInfo = new(program, command);
            process.StartInfo = processInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            var result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
    }
}
