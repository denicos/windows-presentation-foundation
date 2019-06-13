using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfStopClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        wpfStopClock.Ticker _localTicker;
        public MainWindow()
        {
            InitializeComponent();
            _localTicker = (wpfStopClock.Ticker)this.FindResource("localTicker");
        }

        public void startButton_Click(object sender, RoutedEventArgs e)
        {
            _localTicker.Start();
        }
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            _localTicker.Stop();
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            _localTicker.Clear();
        }
    }
}
