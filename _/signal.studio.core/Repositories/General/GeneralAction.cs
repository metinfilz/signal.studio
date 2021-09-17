using System;
using System.Windows;

namespace Signal.Studio.Core.Repositories {
    class GeneralAction : IGeneralAction {
        private readonly GeneralState State;

        public GeneralAction(GeneralState generalState) {
            this.State = generalState;
        }

        public void SetIcon(Uri uri) {
        }

        public void SetPath(string path) {
            this.State.GeneralPath = path;
        }

        public void SetTheme(string theme) {
            Application.Current.Resources.MergedDictionaries.Clear();
            switch (theme) {
                case "light":
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/Signal.Studio.Core;component/Resource/Theme/Light.xaml") });
                    break;
                case "dark":
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/Signal.Studio.Core;component/Resource/Theme/Dark.xaml") });
                    break;
                default:
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/Signal.Studio.Core;component/Resource/Theme/Light.xaml") });
                    break;
            }
        }
    }
    public interface IGeneralAction {
        void SetIcon(Uri uri);
        void SetPath(string path);
        void SetTheme(string theme);
    }
}
