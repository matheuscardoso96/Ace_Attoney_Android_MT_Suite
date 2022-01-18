namespace MTTools.Apk
{
    public static class MovieObbSizeFix
    {
        private static List<GameSmaliLineToUpdate> _gameSmaliLineToUpdates = GetGameSmaliLineToUpdates();

        public static void FixSize(string gameName, string obbPath) 
        {
            GameSmaliLineToUpdate? gameSmaliLinesToUpdate = _gameSmaliLineToUpdates.FirstOrDefault(x => x.GameName.Equals(gameName));
            ArgumentNullException.ThrowIfNull(gameSmaliLinesToUpdate);
            
            var movieObbSize = $"0x{(int)new FileInfo(obbPath).Length:X}".ToLower();
            var basePath = $"{Environment.CurrentDirectory}\\APK\\Exported\\{gameName}\\";

            foreach (var smaliLine in gameSmaliLinesToUpdate.SmaliPathsAndCommands) 
            {
                var smaliPath = $"{basePath}{smaliLine.Key}";
                
                if (!File.Exists(smaliPath))
                    ArgumentNullException.ThrowIfNull($"Arquivo {smaliPath} não encontrado.");

                var lines = File.ReadAllLines(smaliPath);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(smaliLine.Value))
                    {
                        lines[i] = lines[i].Contains("static")? $"{smaliLine.Value}{movieObbSize}L" : $"{smaliLine.Value}{movieObbSize}";
                        break;
                    }
                }

                File.WriteAllLines(smaliPath, lines);
            }

        }

        private static List<GameSmaliLineToUpdate> GetGameSmaliLineToUpdates() 
        {
            var dgs1 = new GameSmaliLineToUpdate()
            {
                GameName = "DGS1",
                SmaliPathsAndCommands = new()
                {
                    [@"smali\jp\co\capcom\daigyakusai\LaunchCheckActivity.smali"]   = "    const-wide/32 v5, ",
                    [@"smali\jp\co\capcom\daigyakusai\e.smali"]                     = ".field public static final d:J = ",
                    [@"smali\jp\co\capcom\daigyakusai\MTFPActivity.smali"]          = "    const-wide/32 v5, "
                }
            };
            var dgs2 = new GameSmaliLineToUpdate() 
            { 
                GameName = "DGS2",
                SmaliPathsAndCommands = new()
                {
                    [@"smali\jp\co\capcom\daigyakusai2jp\e.smali"] = ".field public static final d:J = ",
                    [@"smali\jp\co\capcom\daigyakusai2jp\LaunchCheckActivity.smali"] = "    const-wide/32 v5, ",
                    [@"smali\jp\co\capcom\daigyakusai2jp\MTFPActivity.smali"] = "    const-wide/32 v5, "
                }
            };

            var aa5 = new GameSmaliLineToUpdate() 
            { 
                GameName = "AA5",
                SmaliPathsAndCommands = new()
                {
                    [@"smali\jp\co\capcom\android\mtfp\e.smali"] = ".field public static final d:J = ",
                    [@"smali\jp\co\capcom\android\mtfp\LaunchCheckActivity.smali"] = "    const-wide/32 v5, "
                }
            };

            var aa6 = new GameSmaliLineToUpdate() {
                
                GameName = "AA6",
                SmaliPathsAndCommands = new()
                {
                    [@"smali\jp\co\capcom\gyakusai6en\f.smali"] = ".field public static final d:J = ",
                    [@"smali\jp\co\capcom\gyakusai6en\LaunchCheckActivity.smali"] = "    const-wide/32 v5, ",
                    [@"smali\jp\co\capcom\gyakusai6en\MTFPActivity.smali"] = "    const-wide/32 v5, "
                }
            };

            var gameSmaliLineToUpdates = new List<GameSmaliLineToUpdate>() { dgs1, dgs2, aa5, aa6 };
            
            return gameSmaliLineToUpdates;
        }
    }

    public class GameSmaliLineToUpdate
    {
        public string GameName { get; set; } = "";
        public Dictionary<string,string> SmaliPathsAndCommands { get; set; } = new Dictionary<string, string>();
    }
}
