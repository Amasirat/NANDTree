using System.ComponentModel.Design.Serialization;

namespace Lib;

public class NANDTreeCreator
{
    public static Node CreateNANDTree(int leafcount)
    {
        Node? root =  new Node(1, null, null);
        return CreateNANDTreeUtil(leafcount, root, 0);
    }

    private static Node CreateNANDTreeUtil(int leafcount, Node currentRoot, int height)
    {
        if(height == (int)Math.Log2(leafcount))
        {
            return currentRoot;
        }

        if(currentRoot.value == 1)
        {
            currentRoot.left = new Node(0, null, null);
            currentRoot.right = new Node(1, null, null);
        }
        else
        {
            currentRoot.left = new Node(1, null, null);
            currentRoot.right = new Node(1, null, null);
        }

        currentRoot.value = -1;
        CreateNANDTreeUtil(leafcount, currentRoot.left, height + 1);
        CreateNANDTreeUtil(leafcount, currentRoot.right, height + 1);
        return currentRoot;
    }
}