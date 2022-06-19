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
            inputBuffer = inputBuffer[0] == '0' ? inputBuffer = elem : inputBuffer += elem;
        }
    }

    
}