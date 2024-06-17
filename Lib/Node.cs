namespace Lib;    
public class Node
{
    public Node(TreeValue value, Node left, Node right)
    {
        this.value = value;
        this.left = left;
        this.right = right;
    }
        
    public TreeValue value{get; set;}

    public Node left{get; set;}

    public Node right{get; set;}
}

public enum TreeValue : sbyte
{
    Gate = -1,
    One = 1,
    Zero = 0
}