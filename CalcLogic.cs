using System;
namespace Calculator;

public class CalcLogic
{
    public string inputBuffer = "0";
    public string outputBuffer = "";
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
}