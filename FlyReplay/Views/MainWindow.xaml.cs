using FlyReplay.Connection;
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

namespace FlyReplay {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        public SimState simState { get; set; } = new SimState();

        ISimConnection connection;

        private void ClosePressed(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void MaximizePressed(object sender, RoutedEventArgs e) {
            this.WindowState =
                this.WindowState == WindowState.Normal ?
                WindowState.Maximized : WindowState.Normal;
        }

        private void MinimizePressed(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (connection == null) connection = new FSUIPCSimConnection(simState);
            if (connection.Connect()) MessageBox.Show("Connection successful");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            connection.Disconnect();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            connection.UpdateData();
            Console.WriteLine("Data set");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            connection.SetData();
        }
    }
}
