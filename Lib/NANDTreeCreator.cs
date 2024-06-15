using System.ComponentModel.Design.Serialization;

namespace Lib;

public sealed class NANDTreeCreator
{
    public static Node CreateNANDTree(int leafcount, int evalValue)
    {
        if(evalValue != 0 && evalValue != 1)
            throw new ArgumentException();

        Node root =  new Node(evalValue, null, null);
        return CreateNANDTreeUtil(leafcount, root, 0);
    }

    private static Node CreateNANDTreeUtil(int leafcount, Node currentRoot, int height)
    {
    // This is for knowing if we've reached the maximum height of the tree (basically the boundary condition)
        if(height == (int)Math.Log2(leafcount))
        {
            return currentRoot;
        }

        if(currentRoot.value == 1)
        {
            currentRoot.left = new Node(1, null, null);
            currentRoot.right = new Node(0, null, null);
        }
        else
        {
            currentRoot.left = new Node(1, null, null);
            currentRoot.right = new Node(1, null, null);
        }

        currentRoot.value = -1;//make this node a NAND gate
        CreateNANDTreeUtil(leafcount, currentRoot.left, height + 1);
        CreateNANDTreeUtil(leafcount, currentRoot.right, height + 1);
        return currentRoot;
    }
}