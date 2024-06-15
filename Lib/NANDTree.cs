using System.ComponentModel.Design.Serialization;
using System.Data;

namespace Lib;

public class NANDTree : BinaryTree
{
    public NANDTree(Node root) : base(root)
    {

    }

    public int EvaluateLeftFirst()
    {
        int result = EvaluateLeftFirstUtil(root);

        return result;
    }

    private int EvaluateLeftFirstUtil(Node currentNode)
    {
        if(currentNode.value == -1)
        {
            return EvaluateLeftFirstUtil(currentNode.left);
        }
        else
        {

        }

        return -1;
    }
}