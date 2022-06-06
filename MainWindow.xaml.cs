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
        }

        public void Digital_Button(object sender, EventArgs e)
        {
            if (inputBuffer.Text.Length < 9)
            {
                calc.SendToInputBuffer((sender as Button).Content.ToString());
                inputBuffer.Text = calc.inputBuffer;
            }
        }

        public void DoFloatingNum(object sender, EventArgs e)
        {
            if (!calc.inputBuffer.Contains(",") && calc.inputBuffer != String.Empty)
            {
                calc.SendToInputBuffer((sender as Button).Content.ToString());
                inputBuffer.Text = calc.inputBuffer;
            }
        }

        public void DeleteLastNum(object sender, EventArgs e)
        {
            if (calc.inputBuffer != string.Empty || calc.inputBuffer != "0")
            {
                calc.inputBuffer = calc.inputBuffer.Remove(calc.inputBuffer.Length - 1);
                inputBuffer.Text = calc.inputBuffer;
                if (inputBuffer.Text.Length == 1)
                {
                    inputBuffer.Text = "0";
                }
            }

            
        }
    }
}