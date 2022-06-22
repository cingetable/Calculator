using System;
using System.Windows;
using System.Windows.Controls;
namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal CalcLogic calc = new CalcLogic();
        public MainWindow()
        {
            InitializeComponent();
            inputBuffer.Text = calc.inputBuffer;
        }
        public void Digital_Button(object sender, EventArgs e)
        { 
                calc.SendToInputBuffer((sender as Button).Content.ToString());
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
            inputBuffer.Text = calc.inputBuffer;
        }
        public void ChangeSign(object sender, EventArgs e)
        {
            calc.ChangeSign();
            inputBuffer.Text = calc.inputBuffer;
        }

        public void Plus(object sender, EventArgs e)
        {
            calc.Plus();
            if (calc.state == CalcLogic.State.firstOp)
            {
                inputBuffer.Text = calc.inputBuffer;
            }   
        }

        private void EndCalculating(object sender, RoutedEventArgs e)
        {
           calc.GetResult();
           inputBuffer.Text = calc.inputBuffer;
        }
    }
}