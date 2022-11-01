using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CalculatorFinal
{
    public class Calculator : ICalulator
    {       
        private string castBuffer = "";
        private string updatedTextLine = "";

        #region Calculator's Internal Logic
        private double num1 = 0.0;
        private double num2 = 0.0;
        private Action? Calculate = null;
        private void ChangeCalculateFunction(char setup)
        {
            switch (setup)
            {
                case '+':
                    Calculate = new Action(() => { num1 += num2; });
                    break;
                case '-':
                    Calculate = new Action(() => { num1 -= num2; });
                    break;
                case '×':
                    Calculate = new Action(() => { num1 *= num2; });
                    break;
                case '÷':
                    Calculate = new Action(() => { num1 /= num2; });
                    break;
            }
        }
        #endregion

        #region Clear Calculator Buffers
        private bool clearSign = false;
        private void Clear()
        {
            castBuffer = "";
            num1 = num2 = 0.0;
            Calculate = null;
        }
        #endregion

        #region Calculator's Equal Case
        private void EqualCase()
        {
            num2 = Tools.CastString2Double(castBuffer);
            if (Calculate == null)  // press = before the calculate method.
            {
                if (castBuffer == "")
                {
                    updatedTextLine = "";  // If press equal multiple times in the same position.
                    castBuffer = "";
                }
                else
                    updatedTextLine += "=" + num2;
                return;
            }
            Calculate();
            updatedTextLine += "=" + num1;
            Clear();
        }
        #endregion

        public string ProcessUserInput(in string textLine, string input)
        {
            if (input[0] == 'c' // fire clear button
                || clearSign == true // clean sign
                || !Tools.CastStrValidation(castBuffer)  // validation of cast2numLine failed
                || !Tools.TextStrValidation(textLine) // validation of Textbox line
                )
            {
                Clear();
                updatedTextLine = "";
                clearSign = false;
                return "";
            }

            switch (input[0])
            {
                // Calculate Sign Case
                case '+':
                case '-':
                case '×':
                case '÷':
                    if (textLine == "")
                    {
                        if (input[0] == '-')
                        {
                            updatedTextLine = textLine + '-';
                            castBuffer += '-';
                        }
                        return updatedTextLine;
                    }
                    updatedTextLine = textLine;
                    char lastChar = textLine[textLine.Length - 1];
                    if (Calculate != null)  // If calculate sign has been typed before.
                    {
                        if (lastChar == '+' || lastChar == '-' || lastChar == '×' || lastChar == '÷')  // In the Same place, replace the previous text.
                        {
                            updatedTextLine = textLine.Remove(textLine.Length - 1);
                            if (input[0] == '-')  // For cast: -A * -B 
                            {
                                castBuffer += '-';
                                updatedTextLine = textLine + input;
                                return updatedTextLine;
                            }
                        }
                        else  // If in different place, make setup as '='. and finish all
                        {
                            input = "=";
                            EqualCase();
                            clearSign = true;
                            return updatedTextLine;
                        }
                    }
                    else
                    {
                        num1 = Tools.CastString2Double(castBuffer);  // Only casting when first time in the calculate sign Case
                    }
                    ChangeCalculateFunction(input[0]);
                    updatedTextLine = updatedTextLine + input;
                    castBuffer = "";
                    break;

                // Equal case
                case '=':
                    EqualCase();
                    clearSign = true;
                    break;

                // Delete case
                case 'd':
                    if (textLine == "") // Line isn't empty
                        return "";
                    lastChar = textLine[textLine.Length - 1];
                    if (lastChar <= '9' && lastChar >= '0' || lastChar == '.')  // Line end is num or dot.
                    {
                        updatedTextLine = textLine.Remove(textLine.Length - 1);
                        castBuffer = castBuffer.Remove(castBuffer.Length - 1);
                    }
                    if (lastChar == '-' && textLine.Length == 1)
                    {
                        updatedTextLine = textLine.Remove(textLine.Length - 1);
                        castBuffer = castBuffer.Remove(castBuffer.Length - 1);
                    }
                    break;

                // Num case
                case (<= '9') when (input[0] >= '0' || input[0] == '.'):
                    updatedTextLine = textLine + input[0] ;
                    castBuffer += input[0];
                    break;
            }

            return updatedTextLine;
        }

    }
}
