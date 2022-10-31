using UnityEngine;
public class ConversationTree{
    public int[] tree;
    private string response;
    public static int index=-1;
    public ConversationTree(int[] tree){
        this.tree=tree;
    }
    public Node GetRoot(){
        index++;
        if(tree[index]==-1) return null;
        Node root=new Node(tree[index]);
        root.left=GetRoot();
        root.right=GetRoot();
        return root;
    }    
}