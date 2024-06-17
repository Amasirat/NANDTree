namespace Lib;

public class NANDTree : BinaryTree
{
    public NANDTree(Node root) : base(root)
    {
    }
// a wrapper function for EvaluateUtil, The simple and naive method of NANDTree evaluation
    public int Evaluate()
    {
        if(root.left == null && root.right == null)
            return root.value;

        return EvaluateUtil(root);
    }

    private int EvaluateUtil(Node currentNode)
    {
    // boundary condition
        if(currentNode.value != -1)
            return currentNode.value;
    //recursively evaluate each subtree, 
    //there's only one case where output will be 0 and that is 1 NAND 1 
        if(EvaluateUtil(currentNode.left) == 1 && EvaluateUtil(currentNode.right) == 1)
            return 0;
        else
            return 1;
    }

    public int LeftFirstEvaluate()
    {
        return LeftFirstEvaluateUtil(root);
    }

    private int LeftFirstEvaluateUtil(Node currentNode)
    {
        if(currentNode.value != -1)
            return currentNode.value;

        if(LeftFirstEvaluateUtil(currentNode.left) == 0)
            return 1;
        else
        {
            if(LeftFirstEvaluateUtil(currentNode.right) == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    public int RandomizedFirstEvaluate()
    {
        return RandomizedFirstEvaluateUtil(root);
    }

    private int RandomizedFirstEvaluateUtil(Node currentNode)
    {
        if(currentNode.value != -1)
            return currentNode.value;

        Random rand = new Random();

        int randomChoice = rand.Next(0,1);

        switch(randomChoice)
        {
            case 0:
            {
                if(RandomizedFirstEvaluateUtil(currentNode.left) == 0)
                    return 1;
                break;
            }
            case 1:
            {
                if(RandomizedFirstEvaluateUtil(currentNode.right) == 0)
                    return 1;
                break;
            }
        }

        if(RandomizedFirstEvaluateUtil(currentNode.left) == 1 && RandomizedFirstEvaluateUtil(currentNode.right) == 1)
            return 0;
        else
            return 1;
    }

}