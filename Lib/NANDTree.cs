namespace Lib;

public class NANDTree : BinaryTree
{
    public NANDTree(Node root) : base(root)
    {
    }
// a wrapper function for EvaluateUtil, The simple and naive method of NANDTree evaluation
    public TreeValue Evaluate()
    {
        if(root.Left == null && root.Right == null)
            return root.Value;

        return EvaluateUtil(root);
    }

    private TreeValue EvaluateUtil(Node currentNode)
    {
    // boundary condition
        if(currentNode.Value != TreeValue.Gate)
            return currentNode.Value;
    //recursively evaluate each subtree, 
    //there's only one case where output will be 0 and that is 1 NAND 1 
        if(EvaluateUtil(currentNode.Left) == TreeValue.One && EvaluateUtil(currentNode.Right) == TreeValue.One)
            return TreeValue.Zero;
        else
            return TreeValue.One;
    }

    public TreeValue LeftFirstEvaluate()
    {
        return LeftFirstEvaluateUtil(root);
    }

    private TreeValue LeftFirstEvaluateUtil(Node currentNode)
    {
        if(currentNode.Value != TreeValue.Gate)
            return currentNode.Value;

        if(LeftFirstEvaluateUtil(currentNode.Left) == TreeValue.Zero)
            return TreeValue.One;
        else
        {
            if(LeftFirstEvaluateUtil(currentNode.Right) == TreeValue.One)
            {
                return TreeValue.Zero;
            }
            else
            {
                return TreeValue.One;
            }
        }
    }

    public TreeValue RandomizedFirstEvaluate()
    {
        return RandomizedFirstEvaluateUtil(root);
    }

    private TreeValue RandomizedFirstEvaluateUtil(Node currentNode)
    {   
        if(currentNode.Value != TreeValue.Gate)
            return currentNode.Value;

        Random rand = new Random();

        int randomChoice = rand.Next(0,1);

        switch(randomChoice)
        {
            case 0:
            {
                if(RandomizedFirstEvaluateUtil(currentNode.Left) == TreeValue.Zero)
                    return TreeValue.One;
                break;
            }
            case 1:
            {
                if(RandomizedFirstEvaluateUtil(currentNode.Right) == TreeValue.Zero)
                    return TreeValue.One;
                break;
            }
        }

        if(RandomizedFirstEvaluateUtil(currentNode.Left) == TreeValue.One && RandomizedFirstEvaluateUtil(currentNode.Right) == TreeValue.One)
            return TreeValue.Zero;
        else
            return TreeValue.One;
    }

// Evaluate the probability that a NAND tree with n leaf nodes evaluates to a desired value
    public static float ProbabilityEvaluate(TreeValue value, int leafcount)
    {
        switch(value)
        {
            case TreeValue.One:
                return P1Evaluate(leafcount);
            case TreeValue.Zero:
                return P0Evaluate(leafcount);
            default:
                throw new InvalidDataException("NANDTree.ProbabilityEvaluate aquired invalid data");
        }
    }
// Probability of getting a 0 evaluation for the root of an n leaf tree 
    private static float P0Evaluate(int leafcount)
    {
        if(leafcount == 1)
            return 0.5f;

        leafcount /= 2;
        return P1Evaluate(leafcount) * P1Evaluate(leafcount);
    }
// probability of getting a 1 evaluation for a tree with n leaf nodes is 1 minus the probability that it will get zero
    private static float P1Evaluate(int leafcount)
    {
        if(leafcount == 1)
            return 0.5f;
        return 1 - P0Evaluate(leafcount);
    }
}