using System.ComponentModel.Design.Serialization;

namespace Lib;

public sealed class NANDTreeCreator
{
    public static Node CreateNANDTree(int leafcount, TreeValue evalValue)
    {
        if(evalValue != TreeValue.Zero && evalValue != TreeValue.One)
            throw new ArgumentException();

        Node root =  new Node(evalValue);
        return CreateNANDTreeUtil(leafcount, root, 0);
    }

    private static Node CreateNANDTreeUtil(int leafcount, Node currentRoot, int height)
    {
    // This is for knowing if we've reached the maximum height of the tree (basically the boundary condition)
        if(height == (int)Math.Log2(leafcount))
        {
            return currentRoot;
        }

        if(currentRoot.Value == TreeValue.One)
        {
            currentRoot.Left = new Node(TreeValue.One);
            currentRoot.Right = new Node(TreeValue.Zero);
        }
        else
        {
            currentRoot.Left = new Node(TreeValue.One);
            currentRoot.Right = new Node(TreeValue.One);
        }

        currentRoot.Value = TreeValue.Gate;//make this node a NAND gate
        CreateNANDTreeUtil(leafcount, currentRoot.Left, height + 1);
        CreateNANDTreeUtil(leafcount, currentRoot.Right, height + 1);
        return currentRoot;
    }
}