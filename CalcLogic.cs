using System;
using System.Collections.Generic;
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
    private double memoryCell = 0;
    public bool isBlocked { get; private set; }= false;
    public enum State
    {
        firstOp,
        secondOp
    }
    public State state { get; private set; } = State.firstOp;
    public void SendToInputBuffer(string? elem)
    {
       if (!isBlocked) {
            inputBuffer = inputBuffer[inputBuffer.Length - 1] == '0' && inputBuffer.Length == 1 ? inputBuffer = elem : inputBuffer += elem;
        }  
    }
    public void Delete()
    {
      if (!isBlocked)  {
            if (!inputBuffer.Contains('-')) {
                inputBuffer = inputBuffer.Length == 1 ? inputBuffer = "0" : inputBuffer.Remove(inputBuffer.Length - 1);
            }
            else {
                inputBuffer = inputBuffer.Length == 2 ? inputBuffer = "0" : inputBuffer.Remove(inputBuffer.Length - 1);
            }
        }
    }
    public void SetDot()
    {
        inputBuffer = !inputBuffer.Contains(',') ? inputBuffer += ',' : inputBuffer;
    }
    public void ChangeSign()
    {
        double num = double.Parse(inputBuffer);
        num = num == 0 ? num : -num;
        inputBuffer = num.ToString();
    }
    public void GetResult()
    {
        if (!isBlocked) {
            ExecuteOperation(lastOp);
            state = State.secondOp;
            isBlocked = true;
        }
    }
    public void ExecuteOperation(string opType) 
    { 
        lastOp = opType; 
        if (state == State.firstOp) 
        { 
            accumulator = double.Parse(inputBuffer);
            inputBuffer = "0";
            state = State.secondOp; 
        } 
        else 
        { 
            operand = double.Parse(inputBuffer);
            switch (opType) {
                case "+": accumulator += operand;
                    break;
                case "-": accumulator -= operand;
                    break;
                case "*": accumulator *= operand;
                    break;
                case "/": accumulator /= operand;
                    break;
            }
            inputBuffer = accumulator.ToString(); 
            state = State.firstOp; 
        } 
    }

    public void ResetCalculating() {
        inputBuffer = "0";
        accumulator = 0;
        operand = 0;
        state = State.firstOp;
        isBlocked = false;
    }
    public void MemoryControl(string opType) {
        switch (opType) {
            case "MS": memoryCell = double.Parse(inputBuffer);
                break;
            case "MC": memoryCell = 0;
                break;
            case "MR": inputBuffer = memoryCell.ToString();
                break;
            case "M+": memoryCell += double.Parse(inputBuffer);
                break;
            case "M-": memoryCell -= double.Parse(inputBuffer);
                break;
        }
    }
    public void SetSqruare() {
        inputBuffer = double.Parse(inputBuffer) >= 0 ? 
            inputBuffer = (Math.Sqrt(double.Parse(inputBuffer))).ToString() :
            "Недопустимый ввод";
        isBlocked = true;
    }

    public void OneDivideX() {
        inputBuffer = (1 / double.Parse(inputBuffer)).ToString();
    }

    public void PersentOp() {
        if (state == State.secondOp) {
            operand = accumulator / 100 * operand;
        }
    }
}