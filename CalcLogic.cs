using System;
namespace Calculator;

public class CalcLogic
{
    public string inputBuffer = "";
    public string outputBuffer = "";
    
    public void SendToInputBuffer(string elem)
    {
        inputBuffer += elem;
        
    }

    
}