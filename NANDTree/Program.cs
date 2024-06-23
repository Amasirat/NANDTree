namespace Program;

using Lib;

public class Program
{
    public static void Main()
    {
        Console.WriteLine($" Probability for 0 Evaluation: {NANDTree.ProbabilityEvaluate(TreeValue.Zero, 32768)}");
        Console.WriteLine($" Probability for 1 Evaluation: {NANDTree.ProbabilityEvaluate(TreeValue.One, 32768)}");
    }
}