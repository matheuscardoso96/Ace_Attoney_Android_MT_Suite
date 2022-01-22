using AceAttoney.Android.MTSuite.GUI.Views;
using System.Configuration;

namespace AceAttoney.Android.MTSuite.GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            SetupTools();
            CheckTools();
        }

       
        private void OpenCapcomObbTool(object sender, EventArgs e)
        {
            CapcomObbView capcomObbView = new(ReadSetting("WorkDiretory"));
            capcomObbView.ShowDialog();
        }

        private void OpenMovieObbToolClick(object sender, EventArgs e)
        {
            ZipObb zipObb = new();
            zipObb.ShowDialog();
        }

        private void MSIToolApkClick(object sender, EventArgs e)
        {
            ApkView apkView = new(ReadSetting("WorkDiretory"));
            apkView.ShowDialog();
        }

        private void TMSIWorkPathClick(object sender, EventArgs e)
        {
            SetAWorkPathPath();
        }

        static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            return result;
        }

        static void AddUpdateAppSettings(string key, string value)
        {

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

        }

        private static void SetupTools() 
        {
            string workPath = ReadSetting("WorkDiretory");

            if (workPath.Contains("Not Found"))
            {
                SetAWorkPathPath();
            }
        }

        private static void SetAWorkPathPath() 
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AddUpdateAppSettings("WorkDiretory", dlg.SelectedPath);
                }
            }
        }

        private static void CheckTools()
        {
            string dir = $"{ReadSetting("WorkDiretory")}\\Tools";

            Directory.CreateDirectory(dir);

            if (!File.Exists($"{dir}\\zipalign.exe"))
                File.WriteAllBytes($"{dir}\\zipalign.exe", Properties.Resources.zipalign);

            if (!File.Exists($"{dir}\\ubersigner.jar"))
                File.WriteAllBytes($"{dir}\\ubersigner.jar", Properties.Resources.ubersigner);

            if (!File.Exists($"{dir}\\key.keystore"))
                File.WriteAllBytes($"{dir}\\key.keystore", Properties.Resources.key);

            if (!File.Exists($"{dir}\\apktool.jar"))
                File.WriteAllBytes($"{dir}\\apktool.jar", Properties.Resources.apktool);
        }
    }
}
