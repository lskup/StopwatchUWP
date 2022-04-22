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
using Stopwatch.ViewModel;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Stopwatch.Controls
{
    public sealed partial class MyStopwatchControl : UserControl
    {
        bool resetLapTimeSwitch = false;

        public MyStopwatchControl()
        {
            this.InitializeComponent();
            newStartStopControl.StartStopButtonClick += NewStartStopControl_StartStopButtonClick;
        }

        private void NewStartStopControl_StartStopButtonClick(object sender, EventArgs e)
        {
            resetLapTimeSwitch = !resetLapTimeSwitch;
            if (resetLapTimeSwitch)
            {
                ResetLapTimeButton.Icon = new SymbolIcon(Symbol.Add);
                ResetLapTimeButton.Label = "Lap";
            }
            else
            {
                ResetLapTimeButton.Icon = new SymbolIcon(Symbol.Cancel);
                ResetLapTimeButton.Label = "Reset";
            }

            myStopwatchViewModel.StartStop();
        }

        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            myStopwatchViewModel.StartStop();
        }

        private void LapTimeReset_Click(object sender, RoutedEventArgs e)
        {
            myStopwatchViewModel.ResetOrLapTime();
        }

    }
}
