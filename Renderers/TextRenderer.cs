using System.Linq;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
class TextRenderer:MonoBehaviour{
  
    [SerializeField]
    private TMP_Text textMesh,optionOneTxt,optionTwoTxt;
    private bool finishFlag,startFlag;
    private byte npcNo,phaseNo,clickNo;
    private string[] npcSentences,playerSentences;
    private string response;
    private ConversationTree ct;
    private int index=0,responseLength;
    Node root;
    public Phase GetNpcInfo<Phase>(){
        string jsonString=File.ReadAllText("Assets/Scripts/Statics/CharacterConversationScripts/lightLineMonologue.json");
        Phase npcInfo=JsonUtility.FromJson<Phase>(jsonString);
        return npcInfo;
    }
    public IEnumerator RenderText(char letter){
        startFlag=true;
        yield return new WaitForSeconds(.1f); 
        textMesh.text+=letter;
        index++;
        if(index==responseLength) {
            yield return new WaitForSeconds(.3f); 
            optionOneTxt.text=playerSentences[root.data+1];
            optionTwoTxt.text=playerSentences[root.data+2];
            finishFlag=true;
            yield break;
        }
        StartCoroutine(RenderText(response.ElementAt(index)));
    }
    private void Awake() {
        textMesh.text=" ";
        optionOneTxt.text=" ";
        optionTwoTxt.text=" ";
    }
    private void Start() {
        //npcNo=FindObjectOfType<CurrentNpcHolder>().npcNumber;
        PhaseOneContainer npcInfo=GetNpcInfo<PhaseOneContainer>(); //Checking with phase numbers
        npcSentences=npcInfo.phaseOne[npcNo].nDialogs;
        playerSentences=npcInfo.phaseOne[npcNo].pDialogs;
        ct=new ConversationTree(npcInfo.phaseOne[npcNo].tree);
        root=ct.GetRoot();
    }
    private void Update() {
        if(root==null) FindObjectOfType<SceneManagerTitle>().LoadSavedGame();
        if(startFlag==false){
            response=npcSentences[root.data];
            responseLength=response.Length;           
            StartCoroutine(RenderText(response.ElementAt(index)));
        }   
        else{
        //PlayerChoiceClickTrigger, access firstClick or secondClick
        }
    }
}