using System;
using System.Windows;

namespace Signal.Studio.Workspace.Resource {
    public class ThemeResource : ResourceDictionary {
        private Uri _redSource;
        private Uri _blueSource;
        public Uri RedSource {
            get => _redSource; set {
                _redSource = value;
                UpdateSource();
            }
        }
        public Uri BlueSource {
            get => _blueSource; set {
                _blueSource = value;
                UpdateSource();
            }
        }

        public void UpdateSource() {
            var val = App.Skin == Skin.Red ? RedSource : BlueSource;
            if (val != null && base.Source != val)
                base.Source = val;
        }
    }
}
