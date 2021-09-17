using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;
using Signal.Studio.Base;
using Signal.Studio.Workspace;

namespace Signal.Studio.Cover {
    public sealed partial class SignalCover {
        public static SignalCover Instance { get; } = new();
        private SignalCover() { }

        public void Build(Uri uri) {
            // 1. Config dosyasını oku gerekli yerlere yaz
            // 2. Database dosyasını oluştur/kontrol et
            // 3. Solution odaklı başlatma mekanizmasını çalıştır

            var config = new XmlDocument();
            config.Load(Application.GetResourceStream(uri).Stream);
            CreateDirectory(config);
            ConfigureSplash(config);
        }

        private void ConfigureSplash(XmlDocument doc) {
            var name = doc.GetElementsByTagName("image")[0].Attributes["uri"].Value;
            var image = new Image();
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(name);
            bitmap.EndInit();
            image.Width = bitmap.PixelWidth;
            image.Height = bitmap.PixelHeight;
            image.Source = bitmap;
            var splash = new SplashWindow { Width = image.Width, Height = image.Height };
            splash.Content = image;
            splash.Loaded += async(s, e) => {
                await BeginStartup(doc);
                splash.Close();
            };
            splash.Show();
        }

        private async Task BeginStartup(XmlDocument doc) {
            var logo = doc.GetElementsByTagName("top")[0].Attributes["uri"].Value;
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(logo);
            bitmap.EndInit();
            var startup = new StartupView {};
            var window = new WindowBase { Width = 800, Height = 600, MinWidth = 800, MinHeight = 600, Icon=bitmap, Title="Welcome to Signal Studio"};
            window.Content = startup;
            await Task.Delay(3000);
            Application.Current.MainWindow = window;
            window.Show();
        }
        private void CreateDirectory(XmlDocument doc) {
            var name = doc.GetElementsByTagName("application")[0].Attributes["name"].Value;
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), name);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        }

    }
}
