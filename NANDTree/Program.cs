namespace Program;

using Lib;

public class Program
{
    public static void Main()
    {
        NANDTree tree1 = new NANDTree(NANDTreeCreator.CreateNANDTree(16));
        Console.WriteLine(tree1.Evaluate());
        Console.WriteLine(tree1.LeftFirstEvaluate());
    }
}