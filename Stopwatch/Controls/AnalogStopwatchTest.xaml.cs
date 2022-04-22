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
using Windows.UI.Xaml.Navigation;
//W Windows.UI znajduje się klasa kolor
using Windows.UI;        
//W Shapes znajduje się klasa Rectangle
using Windows.UI.Xaml.Shapes;
//W klasie Media znajduje się klasa SolidBrush
using Windows.UI.Xaml.Media;



// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Stopwatch.Controls
{
    public sealed partial class AnalogStopwatchTest : UserControl
    {
        public AnalogStopwatchTest()
        {
            this.InitializeComponent();
            AddMarkings();
        }

        private void AddMarkings()
        {
            for (int i = 0; i < 360; i+=3)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = (i % 30 == 0) ? 3 : 1;
                rectangle.Height = 15;
                rectangle.Fill = new SolidColorBrush(Colors.Black);
                rectangle.RenderTransformOrigin = new Point(0.5, 0.5);

                TransformGroup transforms = new TransformGroup();
                //Przesunięcie prostokąta do pozycji godziny 12, pamiętając o tym, że punkt obrotu pozostaje
                //w środku tarczy mimo przesunięcia prostokąta(ma współrzędne globalne),
                //dlatego prostokąt za każdym razem ląduje idealnie na swoje miejsce na tarczy
                //zgodnie z kolejnością.
                transforms.Children.Add(new TranslateTransform() { Y = -140 });
                transforms.Children.Add(new RotateTransform() { Angle = i });
                rectangle.RenderTransform = transforms;
                baseGrid.Children.Add(rectangle);
            }




        }
    }
}
