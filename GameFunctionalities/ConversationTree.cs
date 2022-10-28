public class ConversationTree{
    private string[] npcSentences;
    private string[] playerSentences;
    public ConversationTree(string[] npcSentences, string[] playerSentences){
        this.npcSentences=npcSentences;
        this.playerSentences=playerSentences;
    }
    class Node{
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
    class BinaryTree{
        private string response;
        public static int index=-1;
        public Node GetRoot(int[] nodeList){
            index++;
            if(nodeList[index]==-1) return null;
            Node root=new Node(nodeList[index]);
            root.left=GetRoot(nodeList);
            root.right=GetRoot(nodeList);
            return root;
        }
        public void TraverseTree(Node root){
            if(root==null) return;
            else response=npcSentences[root.data];
            
            Console.WriteLine(response+"\n"); 
            string condition=Console.ReadLine();
            if(condition=="0") TraverseTree(root.left);
            else if(condition=="1") TraverseTree(root.right);
        }
    }
}