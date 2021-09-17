using System.Windows;
using System.Windows.Input;

namespace Signal.Studio.Core {
    public partial class WindowBase : Window {
        public WindowBase() {
            InitializeComponent();
        }
        private void CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }
        private void CommandBinding_Executed_Minimize(object sender, ExecutedRoutedEventArgs e) {
            SystemCommands.MinimizeWindow(this);
        }
        private void CommandBinding_Executed_Maximize(object sender, ExecutedRoutedEventArgs e) {
            SystemCommands.MaximizeWindow(this);
        }
        private void CommandBinding_Executed_Restore(object sender, ExecutedRoutedEventArgs e) {
            SystemCommands.RestoreWindow(this);
        }
        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e) {
            SystemCommands.CloseWindow(this);
        }
    }
    public partial class WindowBase {




        public static DependencyProperty VisibilityMinimizeButtonProperty = DependencyProperty.Register("VisibilityMinimizeButton", typeof(bool), typeof(WindowBase), new PropertyMetadata(true));
        public static DependencyProperty VisibilityMaximizeButtonProperty = DependencyProperty.Register("VisibilityMaximizeButton", typeof(bool), typeof(WindowBase), new PropertyMetadata(true));
        public static DependencyProperty VisibilityRestoreButtonProperty = DependencyProperty.Register("VisibilityRestoreButton", typeof(bool), typeof(WindowBase), new PropertyMetadata(false));
        public static DependencyProperty VisibilityCloseButtonProperty = DependencyProperty.Register("VisibilityCloseButton", typeof(bool), typeof(WindowBase), new PropertyMetadata(true));
        public bool VisibilityMinimizeButton {
            get => (bool)GetValue(VisibilityMinimizeButtonProperty);
            set => SetValue(VisibilityMinimizeButtonProperty, value);
        }
        public bool VisibilityMaximizeButton {
            get => (bool)GetValue(VisibilityMaximizeButtonProperty);
            set => SetValue(VisibilityMaximizeButtonProperty, value);
        }
        public bool VisibilityRestoreButton {
            get => (bool)GetValue(VisibilityRestoreButtonProperty);
            set => SetValue(VisibilityRestoreButtonProperty, value);
        }
        public bool VisibilityCloseButton {
            get => (bool)GetValue(VisibilityCloseButtonProperty);
            set => SetValue(VisibilityCloseButtonProperty, value);
        }
    }
}
