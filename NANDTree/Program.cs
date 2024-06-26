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
        }
    }

    private static void MainRenderLoop()
    {
        // Introductory text for program
        Console.WriteLine("Evaluating a NAND Tree");
        Console.WriteLine("This is a companion terminal program for testing our implemented code for the subject in question.");
        Console.WriteLine("Details have been discussed in extensive detail in our README.md on the root folder.");
        Console.WriteLine("You can decide which one of the aspects of this project to test");
        Console.ReadKey();

        while(!programEnd)
        {
            Console.Clear();
            RenderChoices();
            GetChoices();
        }
    }

// method for evaluating and running users choices
    private static void GetChoices()
    {
        int? userChoice = int.Parse(Console.ReadLine());

        switch(userChoice)
        {
            case 0:
                programEnd = true;
                break;
            case 1:
                ShowCreateNANDTree();
                break;
            case 2:
                ShowEvaluationRuntime();
                break;
            case 3:
                ShowTreeProbability();
                break;
            default:
                Console.WriteLine("Your input is not in the list");
                break;
        }
    }
    private static void RenderChoices()
    {
        Console.WriteLine("Choose one by entering a number in the list or exit application by entering 0");
        Console.WriteLine(
            "1.Create a NAND Tree that does not short-circuit with left-first algorithm\n2.Calculate runtime of algorithms\n3.Evaluate the probability of a random NAND Tree\n0.Exit"
        );
    }

    private static void ShowEvaluationRuntime()
    {
        if(memTree == null)
        {
            Console.WriteLine("In order to calculate the runtime of both evaluation runtimes, we need a nand tree to work off of. Would you like to create one?(yes/no)");
            string? createTreeChoice = Console.ReadLine();
            if(createTreeChoice == "yes")
            {
                ShowCreateNANDTree();
            }
            else
            {
                Console.WriteLine("Then we can not proceed...");
                return;
            }
        }
        
        Console.WriteLine("Using NAND tree in memory");

        CalculateRunningTime(memTree);
        Console.WriteLine("Enter any key to continue...");
        Console.ReadKey();
    }

    private static void CalculateRunningTime(NANDTree? treeToEvaluate)
    {
        if(treeToEvaluate == null)
            throw new ArgumentNullException();

        var watch = new System.Diagnostics.Stopwatch();

        watch.Start();

        TreeValue value1 = treeToEvaluate.LeftFirstEvaluate();

        watch.Stop();
        Console.WriteLine(
            $"---Left-first algorithm\nEvaluation: {value1}\nRuntime: {watch.ElapsedMilliseconds}"
        );

        watch.Start();

        TreeValue value2 = treeToEvaluate.LeftFirstEvaluate();

        watch.Stop();
        Console.WriteLine(
            $"---Randomized-first algorithm\nEvaluation: {value2}\nRuntime: {watch.ElapsedMilliseconds}"
        );
    }

// Method that uses NANDTree.ProbabilityEvaluate() for the frontend
    private static void ShowTreeProbability()
    {
        int leafCount = 0;
        while(leafCount != -1)
        {
            Console.Clear();
            Console.WriteLine("Enter the value of k.\nk is used to create a random NAND tree with 2^k leaves (Enter -1 to exit)");
            leafCount = int.Parse(Console.ReadLine());
            if(leafCount == -1)
                break;

            if(leafCount < 0)
            {
                Console.WriteLine("Your chosen number is not valid, try again!");
                Console.ReadLine();
                continue;
            }
            else if(leafCount >= 30)
            {
                Console.WriteLine("This k is too large");
                Console.ReadLine();
                continue;
            }

            Console.WriteLine($"Probability of an expected 1 Evaluation: {NANDTree.ProbabilityEvaluate(TreeValue.One, (int)Math.Pow(2, leafCount))}");
            Console.WriteLine($"Probability of an expected 0 Evaluation: {NANDTree.ProbabilityEvaluate(TreeValue.Zero, (int)Math.Pow(2, leafCount))}");
            Console.WriteLine("Enter any key to continue");
            Console.ReadLine();
        }
    }

    private static void ShowCreateNANDTree()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("Enter the desired end evaluation(either 1 or 0 and smaller than 0 to quit):");
            sbyte boolEval = sbyte.Parse(Console.ReadLine());

            if(boolEval <= -1)
                break;
            else if (boolEval >= 2)
            {
                Console.WriteLine("Value for tree is not valid, try again!");
                continue;
            }
            Console.WriteLine("Enter k for the desired leaf nodes");
            int k = int.Parse(Console.ReadLine());
        // do not accept negative k because stack overflow will occur in NANDTreeCreator otherwise
            if(k < 0)
            {
                Console.WriteLine("Value for k is not valid, try again!");
                continue;
            }

            NANDTree tree = new NANDTree(NANDTreeCreator.CreateNANDTree((int)Math.Pow(2, k), (TreeValue)boolEval));

            Console.WriteLine("Here is the boolean expression resulting from our CreateNANDTree algorithm:");
            Console.WriteLine(tree.GetBooleanExpression());
            Console.WriteLine("Save to program memory?(y/N)");
            string? userChoice = Console.ReadLine();
            if(userChoice == "y")
            {
                memTree = tree;
                Console.WriteLine("Saved to program memory...");
            }
            Console.WriteLine("Enter any key to continue: ");
            Console.ReadLine();
        }
    }

    private static NANDTree? memTree;
    private static bool programEnd = false;
}