using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADBFileTransfer
{
    public static class Constants
    {
        public const string ADB_EXECUTABLE_PATH = @"platform-tools\adb.exe";
    }

    public static class Extensions
    {
        public static Dictionary<string, Image> Icons = new Dictionary<string, Image>()
        {
            {".mp4|.avi|.mkv|.",Properties.Resources.videos },
            {".wav|.mp3|.",Properties.Resources.audios },
            {".png|.jpg|.jpeg|.gif",Properties.Resources.images },
            {".docx|.txt|.ppt|.",Properties.Resources.documents }
        };

        public static Image FromExtension(string extension)
        {
            if (extension.Length < 1) return Properties.Resources.unknown;

            foreach(var item in Icons)
                if (item.Key.Contains(extension)) return item.Value;

            return Properties.Resources.unknown;
        }
    }

    public static class ADBCommands
    {
        public const string ADB_EXECUTABLE_PATH = @"platform-tools\adb.exe";

        private static bool Command(string command, out string output, out string error) {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = ADB_EXECUTABLE_PATH, // ADB'nin bulunduğu dizin
                Arguments = command, // mv komutu ile yeniden adlandırma
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process adbProcess = new Process() { StartInfo = startInfo };
            adbProcess.Start();

            // Çıktıları kontrol et
            output = adbProcess.StandardOutput.ReadToEnd();
            error = adbProcess.StandardError.ReadToEnd();
            adbProcess.WaitForExit();

            return string.IsNullOrEmpty(error);
        }
        
        public static void Rename(string oldFilePath, string newFilePath)
        {
            //oldFilePath = Regex.Escape(oldFilePath);
            //newFilePath = Regex.Escape(newFilePath);

            string command = $"shell mv \"{oldFilePath}\" \"{newFilePath}\"";

            if (!Command(command, out string output, out string error))
            {
                MessageBox.Show("Hata: " + error + "\n" + command); // Eğer bir hata oluşmuşsa, hata mesajını göster
            }
            else
            {
                MessageBox.Show("Dosya başarıyla yeniden adlandırıldı.");
            }
        }
    }
}
