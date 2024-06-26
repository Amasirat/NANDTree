namespace Program;

using Lib;

public class Program
{
    public static void Main()
    {
        try
        {
            MainRenderLoop();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }

    private static void MainRenderLoop()
    {
        while(!programEnd)
        {
        // Introductory text for program
            Console.WriteLine("Evaluating a NAND Tree");
            Console.WriteLine("This is a companion terminal program for testing our implemented code for the subject in question.");
            Console.WriteLine("Details have been discussed in extensive detail in our README.md on the root folder.");
            Console.WriteLine("You can decide which one of the aspects of this project to test");
            Console.ReadLine();
            Console.Clear();

            RenderChoices();
            GetChoices();
        }
    }

    private static void GetChoices()
    {
        int userChoice = int.Parse(Console.ReadLine());

        switch(userChoice)
        {
            case 0:
                programEnd = true;
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                ShowTreeProbability();
                break;
            default:
                Console.WriteLine("Your input is not in the list");
                break;
        }
    }

    private static void RenderChoices()
    {
        Console.WriteLine("Choose one by entering (1-n) or exit application by entering 0");
        Console.WriteLine(
            "1.\n2.\n3.\n4.Evaluate the probability of a random NAND Tree\n0.Exit\n"
        );
    }

    private static void ShowTreeProbability()
    {
        int leafCount = 0;
        while(leafCount != -1)
        {
            Console.Clear();
            Console.WriteLine("Enter the value of the desired count of leaf(leaf has to be 2^k)(Enter -1 to exit)");
            leafCount = int.Parse(Console.ReadLine());
            if(leafCount == -1)
                break;

            if(!IsPowerOfTwo(leafCount))
            {
                Console.WriteLine("Your chosen number is not a power of 2, try again!");
                Console.ReadLine();
                continue;
            }

            Console.WriteLine($"Probability of an expected 1 Evaluation: {NANDTree.ProbabilityEvaluate(TreeValue.One, leafCount)}");
            Console.WriteLine($"Probability of an expected 0 Evaluation: {NANDTree.ProbabilityEvaluate(TreeValue.Zero, leafCount)}");
            Console.ReadLine();
        }
    }

    private static bool IsPowerOfTwo(int number)
    {
        if(number < 0)
            return false;
        if(number == 0)
            return true;

        return (int)(Math.Ceiling(Math.Log2(number) / Math.Log2(2))) == (int)Math.Floor(Math.Log2(number) / Math.Log2(2));
    }
    private static bool programEnd = false;
}