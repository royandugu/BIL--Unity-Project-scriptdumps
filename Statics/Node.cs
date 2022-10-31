public class Node{
        public Node left;
        public Node right;
        public int data;
        public Node(int data){
            this.data=data;
        }
        public Node(Node left, Node right, int data){
            this.left=left;
            this.right=right;
            this.data=data;
        }
    }