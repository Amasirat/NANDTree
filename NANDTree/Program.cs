namespace Program;

using Lib;

public class Program
{
    public static void Main()
    {
        NANDTree tree1 = new NANDTree(NANDTreeCreator.CreateNANDTree(2, 0));
        Console.WriteLine(tree1.Evaluate());
        Console.WriteLine(tree1.RandomizedFirstEvaluate());
    }
}