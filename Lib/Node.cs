    public class Node
    {
        public Node(bool value, Node left, Node right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
        
        public bool? value{get; set;}

        public Node left{get; set;}

        public Node right{get; set;}
    }