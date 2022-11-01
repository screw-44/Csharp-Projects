using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace CalculatorFinal
{
    public class ViewModel : ObservableObject
    {        
        public ViewModel(in ICalulator _calculator) 
        {
            calculator = _calculator;
            Command = new RelayCommand<string>(Process);
        }
        /// <summary>
        /// Binding to the Textbox as the showline.
        /// </summary>
        private string textboxLine = "";
        public string TextboxLine 
        { 
            get { return textboxLine; } 
            set { SetProperty(ref textboxLine, value); } 
        }
        public ICommand Command { get; }
        public ViewModel()
        {
            Command = new RelayCommand<string>(Process);
        }

        private ICalulator calculator;

        private void Process(string setup)
        {
            TextboxLine = calculator.ProcessUserInput(TextboxLine, setup);
        }



    }
}
