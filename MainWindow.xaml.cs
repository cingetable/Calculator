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
            calc.inputBuffer = inputBuffer.Text;
        }

        private void EndCalculating(object sender, RoutedEventArgs e)
        {
           calc.GetResult();
           inputBuffer.Text = calc.inputBuffer;
        }
    }
}