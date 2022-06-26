using System;
using System.Windows;
using System.Windows.Controls;
namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        internal CalcLogic calc = new CalcLogic();
        public void Digital_Button(object sender, EventArgs e)
        { 
               calc.SendToInputBuffer((sender as Button)?.Content.ToString());
                inputBuffer.Text = calc.inputBuffer;
        }
        public void DoFloatingNum(object sender, EventArgs e)
        {
            calc.SetDot();
            inputBuffer.Text = calc.inputBuffer;
        }
        public void DeleteLastNum(object sender, EventArgs e)
        {
           calc.Delete();
            inputBuffer.Text = calc.inputBuffer;
        }
        public void GetResult(object sender, EventArgs e)
        {
          calc.GetResult();
            inputBuffer.Text = calc.inputBuffer;
        }
        public void ChangeSign(object sender, EventArgs e)
        {
            calc.ChangeSign();
            inputBuffer.Text = calc.inputBuffer;
        }
        public void Operation(object sender, EventArgs e)
        {
          //  outputBuffer.Text = calc.state.ToString();
            string operationType = (sender as Button).Content.ToString();
            SetOperationType(operationType);
            if (calc.state == CalcLogic.State.firstOp)
            {
                inputBuffer.Text = calc.inputBuffer;
                SetOperationType(operationType);
            } 
        }
        private void SetOperationType(string opType) {
            switch (opType)
            {
                case "+": calc.Plus();
                    break;
                case "-": calc.Minus();
                    break;
                case "*": calc.Multiply();
                    break;
                case "/": calc.Divide();
                    break;
            }
        }
        private void ClearCurrentNum(object sender, RoutedEventArgs e) {
          
                inputBuffer.Text = "0";
                calc.inputBuffer = inputBuffer.Text;
            
        }
        private void ClearCalculation(object sender, RoutedEventArgs e) {
            calc.ResetCalculating();
            outputBuffer.Text = "";
            inputBuffer.Text = calc.inputBuffer;
            
        }
        public void Memory(object sender, RoutedEventArgs e) {
            string operationType = (sender as Button).Content.ToString();
            calc.MemoryControl(operationType);
            inputBuffer.Text = calc.inputBuffer;
        }

        public void Square(object sender, RoutedEventArgs e) {
            calc.SetSqruare();
            
            inputBuffer.Text = calc.inputBuffer;
        }
    }
}