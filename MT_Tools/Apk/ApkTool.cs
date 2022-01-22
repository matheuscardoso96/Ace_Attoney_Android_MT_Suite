using System.Diagnostics;

namespace MTTools.Apk
{
    public class ApkTool
    {
        public ApkTool(string workdirectory)
        {
            _apkExportPath = $"{workdirectory}\\APK\\Exported\\";
            _newApkPath = $"{workdirectory}\\APK\\New\\";
            _apkToolPath = $"{workdirectory}\\Tools\\apktool.jar";
            _ubersignerPath = $"{workdirectory}\\Tools\\ubersigner.jar";
            _zipalignPath = $"{workdirectory}\\Tools\\zipalign.exe";
            _keystorePath = $"{workdirectory}\\Tools\\key.keystore";
        }

        private readonly string _apkExportPath = string.Empty;
        private  readonly string _newApkPath = string.Empty;
        private readonly string _apkToolPath = string.Empty;
        private readonly string _ubersignerPath = string.Empty;
        private readonly string _zipalignPath = string.Empty;
        private readonly string _keystorePath = string.Empty;
        private const string _fileNotFoundMsg = "Arquivo .apk não encontrado.";    
        private const string _directoryEmptyErrorMsg = "O diretorio selecionado está vazio.";  
        private const string _apkDecompileError = "Erro ao decompilar apk, verifique se o java está instalado.";
        private const string _apkCompileSuccessMsg = "I: Built apk";
        private const string _apkCompileError = "Erro ao compilar apk, verifique se o java está instalado.";
        private const string _jarsignerSuccessMsg = "Successfully processed 1 APKs";
        private const string _jarsignerErrorMsg = "Falha ao assinar apk, verifique se o programa jarsigner está na pasta tools.";
        private const string _zipalignSuccessMsg = "Verification succesful";
        private const string _zipalignErrorMsg = "Falha ao ultilizar o ZipAlign, verifique se o programa ZipAlign está na pasta tools.";

        

        public void DecompileApk(string apkPath, string gameName) 
        {
            if (!File.Exists(apkPath))
                throw new FileNotFoundException(_fileNotFoundMsg);

            _ = Directory.CreateDirectory(_apkExportPath);

            _ = CommandExecute("java.exe", CreateDecompileCommand(apkPath, $"{_apkExportPath}{gameName}"));
            
            if (!Directory.Exists($"{_apkExportPath}{gameName}"))
                throw new DirectoryNotFoundException(_apkDecompileError);
        }

        public void CompileApk(string decompiledApkPath, string apkName)
        {

            if (IsDirectoryEmpty(decompiledApkPath))
                throw new Exception(_directoryEmptyErrorMsg);

            _ = Directory.CreateDirectory(_newApkPath);
           
           var result = CommandExecute("java.exe", CreateCompileCommmand(decompiledApkPath));

            if (!result.Contains(_apkCompileSuccessMsg))
                throw new FileNotFoundException(_apkCompileError);

            var apkNewPath = Directory.GetFiles($"{decompiledApkPath}\\dist", "*.apk").First();         
            
            SignApk(apkNewPath);
            ZipAlignApk(apkNewPath, apkNewPath.Replace(".apk","_signed.apk"));
            
            File.Delete(apkNewPath);
            File.Move(apkNewPath.Replace(".apk", "_signed.apk"), $"{_newApkPath}{apkName}_{DateTime.Now:dd-MM-yyyy-HH-mm-ss}.apk");        
        }

        private void SignApk(string apkPath) 
        {
           var result = CommandExecute("java.exe", CreateSignApkCommmand(apkPath));

            if (!result.Contains(_jarsignerSuccessMsg))
               throw new Exception(_jarsignerErrorMsg);
        }

        private void ZipAlignApk(string apkPath, string signedApkPath)
        {
            var result = CommandExecute(_zipalignPath, CreateZipAlignCommmand(apkPath, signedApkPath));

            if (!result.Contains(_zipalignSuccessMsg))
                throw new Exception(_zipalignErrorMsg);
        }

        private bool IsDirectoryEmpty(string path) 
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }


        private string CreateDecompileCommand(string apkPath, string destPath) 
        {
            return $"-jar \"{_apkToolPath}\" -f d \"{apkPath}\" -o \"{destPath}\"";
        }

        private string CreateCompileCommmand(string apkExportedPath) 
        {
            return $"-jar \"{_apkToolPath}\" b \"{apkExportedPath}\"";
        }

        private string CreateSignApkCommmand(string apkPath)
        {
            return $"-jar \"{_ubersignerPath}\" -a \"{apkPath}\" --ks \"{_keystorePath}\" --ksAlias capcom --ksPass capcom2022 --ksKeyPass capcom2022";
        }

        private string CreateZipAlignCommmand(string apkPath, string signedApkPath)
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
