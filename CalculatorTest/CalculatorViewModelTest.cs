#region Notes
    // This file shows two different apporch to test the view Model
    // Method 1 test the overall functionality of the viewModel -- Calculate after taking string input. The tested Unit is ViewModel.
    // Method 2 test only one step or say one action of the viewModel -- Clear action itself. The tested Unit is Calculator.(Bussiness Logic)!!!
#endregion

using CalculatorFinal;

namespace CalculatorFinal
{
    [TestClass]
    public class CalculatorViewModelTest
    {
        [TestMethod]
        public void CanViewModelClean() // Test method 2
        {
            var calculator = new Calculator();
            var viewModel = new ViewModel(calculator);
            viewModel.TextboxLine = "12345";
            viewModel.Command.Execute("c");
            Assert.AreEqual(viewModel.TextboxLine, "");
        }

        [TestMethod]
        public void CanViewModelAdd()  // Test method 1
        {
            var calculator = new Calculator();
            var viewModel = new ViewModel(calculator);
            string inputs = "1+1=";
            for (int i = 0; i < inputs.Length; i++)
            {
                viewModel.Command.Execute(char.ToString(inputs[i]));
            }
            Assert.AreEqual(viewModel.TextboxLine, "1+1=2");
        }

    }
}
