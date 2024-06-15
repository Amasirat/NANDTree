    public class Node
    {
        public Node(int value, Node left, Node right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
        
        public int value{get; set;}

        public Node left{get; set;}

        public Node right{get; set;}
    }