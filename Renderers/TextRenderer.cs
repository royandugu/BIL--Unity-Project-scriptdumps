using System;
using System.Linq;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
class TextRenderer:MonoBehaviour{
    Npc npc;
    [SerializeField]
    private TMP_Text textMesh,optionOneTxt,optionTwoTxt;
    private PlayerChoiceClickTrigger playerChoiceClickTrigger;
    private bool startFlag;
    private byte phaseNo,clickNo;
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
            index=0;
            yield return new WaitForSeconds(.3f); 
            optionOneTxt.text=playerSentences[root.data+1];
            optionTwoTxt.text=playerSentences[root.data+2];
            yield break;
        }
        StartCoroutine(RenderText(response.ElementAt(index)));
    }
    private void Start() {
        npc=FindObjectOfType<CurrentNpcHolder>().npc;
        playerChoiceClickTrigger=FindObjectOfType<PlayerChoiceClickTrigger>();
        PhaseOneContainer npcInfo=GetNpcInfo<PhaseOneContainer>(); //Checking with phase numbers
        npcSentences=npcInfo.phaseOne[npc.npcNumber].nDialogs;
        playerSentences=npcInfo.phaseOne[npc.npcNumber].pDialogs;
        ct=new ConversationTree(npcInfo.phaseOne[npc.npcNumber].tree);
        ct.index=-1;
        root=ct.GetRoot();
    }
    private void Update() {
        try{
            if(startFlag==false){
                textMesh.text=" ";
                optionOneTxt.text=" ";
                optionTwoTxt.text=" ";
                response=npcSentences[root.data];
                responseLength=response.Length;           
                StartCoroutine(RenderText(response.ElementAt(index)));
            }   
            else{
                if(playerChoiceClickTrigger.firstChoice==true) {
                    startFlag=false;
                    root=root.left;
                    playerChoiceClickTrigger.firstChoice=false;
                    playerChoiceClickTrigger.secondChoice=false;
                }
                else if(playerChoiceClickTrigger.secondChoice==true) {
                    startFlag=false;
                    root=root.right;
                    playerChoiceClickTrigger.firstChoice=false;
                    playerChoiceClickTrigger.secondChoice=false;
                }
            }
        }
        catch(Exception e){
            index=0;
            npc.canTalk=false;  //This change should be done to the json file         
            SceneLoader.LoadScene(SceneLoader.Scenes.GameScene);
        }
    }
}