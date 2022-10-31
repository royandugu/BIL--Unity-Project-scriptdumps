using System.IO;
using UnityEngine;
using TMPro;
class TextRenderer:MonoBehaviour{
  
    [SerializeField]
    private TMP_Text textMesh;
    private byte npcNo,phaseNo;
    private string[] npcSentences,playerSentences;
    public Phase GetNpcInfo<Phase>(){
        string jsonString=File.ReadAllText("Assets/Scripts/Statics/CharacterConversationScripts/lightLineMonologue.json");
        Phase npcInfo=JsonUtility.FromJson<Phase>(jsonString);
        return npcInfo;
    }
    public void TraverseTree(Node root){
            if(root==null) return;
            textMesh.text=playerSentences[root.data];           
            // else response=npcSentences[root.data];
            
            // Console.WriteLine(response+"\n"); 
            // string condition=Console.ReadLine();
            // if(condition=="0") TraverseTree(root.left);
            // else if(condition=="1") TraverseTree(root.right);
    }
    private void Start() {
        //npcNo=FindObjectOfType<CurrentNpcHolder>().npcNumber;
        PhaseOneContainer npcInfo=GetNpcInfo<PhaseOneContainer>(); //Checking with phase numbers
        npcSentences=npcInfo.phaseOne[npcNo].nDialogs;
        playerSentences=npcInfo.phaseOne[npcNo].pDialogs;
        ConversationTree ct=new ConversationTree(npcInfo.phaseOne[npcNo].tree);
        Node root=ct.GetRoot(); 
        TraverseTree(root);
    }    
    private void Update(){
        
    }
}