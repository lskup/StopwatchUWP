using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Stopwatch.Controls
{
    public sealed partial class StartStopControl : UserControl
    {
        public event EventHandler StartStopButtonClick;

        public StartStopControl()
        {
            this.InitializeComponent();
        }

        private void StartStopButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is AppBarToggleButton)
            {
                AppBarToggleButton toggleButton = sender as AppBarToggleButton;
                toggleButton.Icon = new SymbolIcon(Symbol.Pause);
                toggleButton.Label = "Pause";
            }
            StartStopButtonClick?.Invoke(this,null);
        }

        private void StartStopButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is AppBarToggleButton)
            {
                AppBarToggleButton toggleButton = sender as AppBarToggleButton;
                toggleButton.Icon = new SymbolIcon(Symbol.Play);
                toggleButton.Label = "Start";
            }
            StartStopButtonClick?.Invoke(this,null);

        }
    }
}
