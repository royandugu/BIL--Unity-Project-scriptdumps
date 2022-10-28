using System.IO;
using UnityEngine;
using TMPro;
class TextRenderer:MonoBehaviour{
  
    [SerializeField]
    private TMP_Text textMesh;
    private byte npcNo,phaseNo;
    private byte[] convTree;
    public Phase GetNpcInfo<Phase>(){
        string jsonString=File.ReadAllText("Assets/Scripts/Statics/CharacterConversationScripts/lightLineMonologue.json");
        Phase npcInfo=JsonUtility.FromJson<Phase>(jsonString);
        return npcInfo;
    }
    private void Start() {
        npcNo=FindObjectOfType<CurrentNpcHolder>().npcNumber;
        PhaseOneContainer npcInfo=GetNpcInfo<PhaseOneContainer>(); //Checking with phase numbers
        convTree=npcInfo.phaseOne[npcNo].tree;
    }    
    private void Update(){
        BinaryTree bt=new BinaryTree();
        Node n=bt.GetRoot(convTree);
        bt.TraverseTree(n);
    }
}