using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CalculatorFinal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var calculator = new Calculator();

            var viewModel = new ViewModel(calculator);

            MainWindow = new MainWindow
            {
                DataContext = viewModel
            };

            MainWindow.Show();
        }
    }
}
