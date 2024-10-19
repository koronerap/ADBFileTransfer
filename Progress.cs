using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBFileTransfer
{
    public partial class Progress : Form
    {
        private Thread uploadThread;
        private long fileSize;
        private string targetFilePath;
        private string sourceFilePath;
        private DateTime uploadStartTime;

        public Progress()
        {
            InitializeComponent();
        }

        public void StartUpload(string deviceId, string sourcePath, string targetPath)
        {
            // Yükleme işlemi için yeni bir thread başlatılıyor
            sourceFilePath = sourcePath;

            destinationLabel.Text = $"Transferring {Path.GetFileName(sourceFilePath)} to {Path.GetDirectoryName(sourceFilePath)}.";

            uploadThread = new Thread(() => UploadFileWithAdb(deviceId, sourcePath, targetPath));
            uploadThread.IsBackground = true; // Arka planda çalışacak thread
            uploadThread.Start();
        }

        private void UploadFileWithAdb(string deviceId, string sourcePath, string targetPath)
        {
            try
            {
                // Kaynak dosyanın boyutunu alıyoruz
                fileSize = new FileInfo(sourcePath).Length;
                targetFilePath = targetPath;

                // Yükleme başlangıç zamanını al
                uploadStartTime = DateTime.Now;

                // ADB komutu ile dosyayı Quest cihazına yüklüyoruz
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = Constants.ADB_EXECUTABLE_PATH,
                    Arguments = $"-s {deviceId} push \"{sourcePath}\" \"{targetPath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process adbProcess = new Process { StartInfo = startInfo };
                adbProcess.Start();

                // Yükleme sırasında belirli aralıklarla boyutu kontrol etmek için
                Thread progressThread = new Thread(MonitorProgress);
                progressThread.Start();

                adbProcess.WaitForExit();
                progressThread.Join(); // İlerleme takibi tamamlandığında thread'i durdur

                UpdateProgress(100); // Yükleme tamamlandığında progress bar'ı %100 yap

            }
            catch (Exception ex)
            {
                MessageBox.Show("Yükleme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void MonitorProgress()
        {
            try
            {
                long uploadedSize = 0;

                // Dosya tamamen yüklenene kadar periyodik olarak boyutu kontrol et
                while (uploadedSize < fileSize)
                {
                    uploadedSize = GetFileSizeOnQuest(targetFilePath);

                    if (uploadedSize >= 0)
                    {
                        // Yükleme hızını hesapla
                        TimeSpan elapsed = DateTime.Now - uploadStartTime;
                        double uploadSpeed = uploadedSize / 1024.0 / elapsed.TotalSeconds; // KB/s cinsinden hız

                        int progressPercentage = (int)((double)uploadedSize / fileSize * 100);
                        UpdateProgress(progressPercentage, uploadSpeed);
                    }

                    Thread.Sleep(500); // 500 ms aralıklarla kontrol et
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İlerleme takibi sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private long GetFileSizeOnQuest(string filePath)
        {
            try
            {
                filePath = Regex.Escape(filePath);

                // ADB komutu ile hedef dosyanın boyutunu alıyoruz
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = Constants.ADB_EXECUTABLE_PATH,
                    Arguments = $"shell ls -l \"{filePath}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process adbProcess = new Process { StartInfo = startInfo };
                adbProcess.Start();

                string output = adbProcess.StandardOutput.ReadToEnd();
                adbProcess.WaitForExit();

                // Çıktıyı işleyerek dosya boyutunu alıyoruz
                string[] outputParts = output.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (outputParts.Length >= 5 && long.TryParse(outputParts[4], out long fileSizeOnQuest))
                {
                    return fileSizeOnQuest;
                }

                return 0; // Eğer dosya bulunamazsa veya hatalıysa 0 döndür
            }
            catch
            {
                return -1; // Hata olursa -1 döndür
            }
        }

        private void UpdateProgress(int percentage, double uploadSpeed = 0)
        {
            // UI thread'de ProgressBar ve Label'ı güncelle
            if (InvokeRequired)
            {
                Invoke(new Action<int, double>(UpdateProgress), percentage, uploadSpeed);
                return;
            }

            progressBar.Value = percentage;

            // Yükleme hızı (KB/s veya MB/s) ve dosya ismini göster
            string speedText = uploadSpeed > 1024 ? $"{uploadSpeed / 1024:F2} MB/s" : $"{uploadSpeed:F2} KB/s";
            labelProgress.Text = $"{percentage}% tamamlandı - Hız: {speedText}";
            Text = $"{percentage}% tamamlandı";

            if(percentage == 100 && uploadSpeed == 0)
            {
                //MessageBox.Show("Yükleme işlemi başarıyla tamamlandı: " + sourceFilePath);
                Close();
            }
        }
    }
}
