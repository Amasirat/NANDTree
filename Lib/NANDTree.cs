namespace Lib;

public class NANDTree : BinaryTree
{
    public NANDTree(Node root) : base(root)
    {
    }
// a wrapper function for EvaluateUtil, The simple and naive method of NANDTree evaluation
    public TreeValue Evaluate()
    {
        if(root.left == null && root.right == null)
            return root.value;

        return EvaluateUtil(root);
    }

    private TreeValue EvaluateUtil(Node currentNode)
    {
    // boundary condition
        if(currentNode.value != TreeValue.Gate)
            return currentNode.value;
    //recursively evaluate each subtree, 
    //there's only one case where output will be 0 and that is 1 NAND 1 
        if(EvaluateUtil(currentNode.left) == TreeValue.One && EvaluateUtil(currentNode.right) == TreeValue.One)
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
        if(currentNode.value != TreeValue.Gate)
            return currentNode.value;

        if(LeftFirstEvaluateUtil(currentNode.left) == TreeValue.Zero)
            return TreeValue.One;
        else
        {
            if(LeftFirstEvaluateUtil(currentNode.right) == TreeValue.One)
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
        if(currentNode.value != TreeValue.Gate)
            return currentNode.value;

        Random rand = new Random();

        int randomChoice = rand.Next(0,1);

        switch(randomChoice)
        {
            case 0:
            {
                if(RandomizedFirstEvaluateUtil(currentNode.left) == TreeValue.Zero)
                    return TreeValue.One;
                break;
            }
            case 1:
            {
                if(RandomizedFirstEvaluateUtil(currentNode.right) == TreeValue.Zero)
                    return TreeValue.One;
                break;
            }
        }

        if(RandomizedFirstEvaluateUtil(currentNode.left) == TreeValue.One && RandomizedFirstEvaluateUtil(currentNode.right) == TreeValue.One)
            return TreeValue.Zero;
        else
            return TreeValue.One;
    }
}