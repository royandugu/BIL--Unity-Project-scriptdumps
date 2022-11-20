using System;
using System.Linq;
using System.Collections;
using UnityEngine;
using TMPro;
class TextRenderer:MonoBehaviour{
    Npc npc;
    [SerializeField]
    private TMP_Text textMesh,optionOneTxt,optionTwoTxt;
    [SerializeField]
    private GameObject firstButton,secondButton;
    private PlayerChoiceClickTrigger playerChoiceClickTrigger;
    private int[,] responseFlag;
    private bool startFlag,onceChanged=false;
    private byte phaseNo,clickNo;
    private string[] npcSentences,playerSentences;
    private string response;
    private ConversationTree ct;
    private int index=0,responseLength,traverseTime=0;
    Node root;
    //Unity built in functions
    private void Start() {
        npc=FindObjectOfType<CurrentNpcHolder>().npc;
        playerChoiceClickTrigger=FindObjectOfType<PlayerChoiceClickTrigger>();
        PhaseOneContainer npcInfo=GetNpcInfo<PhaseOneContainer>(); //Checking with phase numbers
        npcSentences=npcInfo.phaseOne[npc.npcNumber].nDialogs;
        playerSentences=npcInfo.phaseOne[npc.npcNumber].pDialogs;
        responseFlag=ResponseFlagHolder.GetResponseFlag(npc.npcNumber);
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
                if(traverseTime!=0 && responseFlag[traverseTime,root.data]==0) EndSettings();
                else response=npcSentences[responseFlag[traverseTime,root.data]];
                responseLength=response.Length;          
                StartCoroutine(RenderText(response.ElementAt(index)));
            }   
            else{
                if(playerChoiceClickTrigger.firstChoice==true) {
                    startFlag=false;
                    root=root.left;
                    traverseTime++;
                    playerChoiceClickTrigger.firstChoice=false;
                    playerChoiceClickTrigger.secondChoice=false;
                }
                else if(playerChoiceClickTrigger.secondChoice==true) {
                    startFlag=false;
                    root=root.right;
                    traverseTime++;
                    playerChoiceClickTrigger.firstChoice=false;
                    playerChoiceClickTrigger.secondChoice=false;
                }
            }
        }
        catch(Exception){
            EndSettings();
        }
    }
    //User defined functions
    public Phase GetNpcInfo<Phase>(){
        string jsonString=Resources.Load<TextAsset>("CharacterConversationScripts/lightLineMonologue").text;
        Phase npcInfo=JsonUtility.FromJson<Phase>(jsonString);
        return npcInfo;
    }
    public void EndSettings(){
        index=0;
        if(npc.isPrimary) Player.pSConv++;
        else Player.sSConv++; 
        BasicGameDetails.isTempOld=true;
        SceneLoader.LoadScene(SceneLoader.Scenes.GameScene);
    }
    public IEnumerator RenderText(char letter){
        if(firstButton.activeSelf) firstButton.SetActive(false);
        if(secondButton.activeSelf) secondButton.SetActive(false);
        startFlag=true;
        yield return new WaitForSeconds(.1f); 
        textMesh.text+=letter;
        index++;
        if(index==responseLength) {
            index=0;
            yield return new WaitForSeconds(.3f); 
            try{
                firstButton.SetActive(true);
                optionOneTxt.text=playerSentences[root.left.data];
            }
            catch(Exception){
                firstButton.SetActive(false);
            }
            try{
                secondButton.SetActive(true);
                optionTwoTxt.text=playerSentences[root.right.data];
            }
            catch(Exception){
                secondButton.SetActive(false);
            }
            yield break;
        }
        StartCoroutine(RenderText(response.ElementAt(index)));
    }
}