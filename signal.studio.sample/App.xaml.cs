using System;
using System.Windows;
using Signal.Studio.Cover;

namespace Signal.Studio.Sample {
    public partial class App : Application {
        private readonly string ConfigPath = "pack://application:,,,/signal.studio;component/configuration.xml";
        public App() {
            SignalCover.Instance.Build(new Uri(ConfigPath));
        }
    }
}
