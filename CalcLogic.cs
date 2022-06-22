using System;
using System.Diagnostics;

namespace Calculator;
/// <summary>
/// logic for MainWindow.xaml
/// </summary>
public class CalcLogic
{
    public string inputBuffer = "0";
    public string outputBuffer = "";
    
    private double accumulator;
    private double operand;
    
    private string lastOp = "";
    
    public enum State
    {
        firstOp,
        secondOp
    }

    public State state { get; private set; } = State.firstOp;
    public void SendToInputBuffer(string elem)
    {
        if (inputBuffer.Length < 9)
        {
            inputBuffer = inputBuffer[inputBuffer.Length - 1] == '0' ? inputBuffer = elem : inputBuffer += elem;
        }
    }
    public void Delete()
    {
        if (!inputBuffer.Contains('-'))
        {
            inputBuffer = inputBuffer.Length == 1 ? inputBuffer = "0" : inputBuffer.Remove(inputBuffer.Length - 1);
        }
        else
        {
            inputBuffer = inputBuffer.Length == 2 ? inputBuffer = "0" : inputBuffer.Remove(inputBuffer.Length - 1);
        }
    }
    public void SetDot()
    {
        inputBuffer = !inputBuffer.Contains(',') ? inputBuffer += ',' : inputBuffer;
    }
    public void ChangeSign()
    {
        double num = double.Parse(inputBuffer);
        num = -num;
        inputBuffer = num.ToString();
    }

    public void GetResult()
    {
        if (lastOp == "+") inputBuffer = (double.Parse(inputBuffer) + accumulator).ToString();

        state = State.firstOp;
    }
    public void Plus() 
    { 
        Console.WriteLine(state.ToString());
        lastOp = "+"; 
        if (state == State.firstOp) 
        { 
            accumulator = double.Parse(inputBuffer);
            inputBuffer = "0";
            state = State.secondOp; 
        } 
        else 
        { 
            operand = double.Parse(inputBuffer); 
            accumulator += operand; 
            inputBuffer = accumulator.ToString(); 
            state = State.firstOp; 
        } 
    }

    
}