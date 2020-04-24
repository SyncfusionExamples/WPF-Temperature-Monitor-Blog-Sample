using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_RadialGauge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = null;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var data= this.grid.DataContext as ViewModel;
            var _outsideValue = -10.55;
            var _insideValue = 20.75;
            var random = new Random();
            data.InsideValue = _insideValue + (random.NextDouble() * 5);
            data.OutsideValue = _outsideValue + (random.NextDouble() * -5);
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        private double _outsideValue = -10.55;
        private double _insideValue = 20.75;
        public double OutsideValue
        {
            get
            {
                return _outsideValue;

            }
            set
            {
                _outsideValue = value;
                _outsideValue = Math.Round(_outsideValue, 2);
                OnPropertyRaised("OutsideValue");
            }
        }

        public double InsideValue
        {
            get
            {
                return _insideValue;

            }
            set
            {
                _insideValue = value;
                _insideValue = Math.Round(_insideValue, 2);
                OnPropertyRaised("InsideValue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    }
}
