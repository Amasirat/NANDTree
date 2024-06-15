using System.ComponentModel.Design.Serialization;
using System.Data;

namespace Lib;

public class NANDTree : BinaryTree
{
    public NANDTree(Node root) : base(root)
    {

    }

    public bool? EvaluateLeftFirst()
    {
        bool? result = EvaluateLeftFirstUtil(root);

        return result;
    }

    

    public bool Evaluate()
    {

    }

    private bool? EvaluateLeftFirstUtil(Node currentNode)
    {
        return null;
    }
}