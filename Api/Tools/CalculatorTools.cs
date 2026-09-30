using ModelContextProtocol.Server;
using System.ComponentModel;

namespace McpLearning.Tools;

[McpServerToolType]
public static class CalculatorTools
{
    [McpServerTool]
    [Description("Adds two numbers together.")]
    public static int Add(
        int firstNumber,
        int secondNumber)
    {
        return firstNumber + secondNumber;
    }

    [McpServerTool]
    [Description("Subtracts the second number from the first number.")]
    public static int Subtract(
        int firstNumber,
        int secondNumber)
    {
        return firstNumber - secondNumber;
    }

    [McpServerTool]
    [Description("Multiplies two numbers.")]
    public static int Multiply(
        int firstNumber,
        int secondNumber)
    {
        return firstNumber * secondNumber;
    }
}