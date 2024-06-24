namespace Lib;

public class BinaryTree
{
    public BinaryTree(Node root)
    {
        if(root == null)
            throw new ArgumentNullException();
        this.root = root;
    }
    protected Node root;
}
