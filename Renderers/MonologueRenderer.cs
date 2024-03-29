using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class MonologueRenderer:MonoBehaviour{
    [SerializeField]
    private TMPro.TMP_Text monologueText,skipNextButtonText;
    [SerializeField]
    private GameObject skipNextButton,renderContainer;
    private string monologue;
    private int monologueLength,index=0;
    private bool wait=false,skip=false;
    //Unity Built in
    private void Update() {
        if(Game.resetMonologue) monologueText.text=" ";
        if(Game.playMonologue) FetchAndPlay();
    }
    //User defined functions
    public void FetchAndPlay(){
        monologue=GetMonologueInfo();
        monologueLength=monologue.Length;
        StartCoroutine(RenderMonologue(monologue.ElementAt(index)));
    }
    public string GetMonologueInfo(){
        string jsonString=Resources.Load<TextAsset>("CharacterConversationScripts/monologues").text;
        MonologueInfo value=new MonologueInfo();
        IDictionary<string,MonologueInfo> parsed=new Dictionary<string,MonologueInfo>();
        parsed=JsonConvert.DeserializeObject<IDictionary<string,MonologueInfo>>(jsonString);
        parsed.TryGetValue("monologues",out value);
        return value.initials[(int)Player.selfConv++];
    }
    public System.Collections.IEnumerator RenderMonologue(char letter){
        Game.playMonologue=false;
        Game.resetMonologue=false;
        Player.canMove=false;
        skipNextButtonText.text="Skip";
        SetContainerAndButtonStatus(true);
        if(wait) {
            wait=false;
            yield return new WaitForSeconds(.4f);
        }
        else yield return new WaitForSeconds(.1f);
        if(letter=='.')  wait=true;
        monologueText.text+=letter;
        index++;
        if(index==monologueLength) {
            skipNextButtonText.text="Next";
            yield break;
        }
        if(skip) {
            FinishRender();
            yield break;
        }
        StartCoroutine(RenderMonologue(monologue.ElementAt(index)));       
    }
    public void FinishRender(){
        SetContainerAndButtonStatus(false);
        if(Game.fadeEnd==true) {
            //Play a certain animation

            Player.canMove=true;
        }
        Game.fadeStart=true;
        Game.resetMonologue=true;
        index=0;
        skip=false;
    }
    public void SetContainerAndButtonStatus(bool value){
        renderContainer.SetActive(value);
        skipNextButton.SetActive(value);
    }
    public void SkipMonologue(){
        skip=true;
        if(index == monologueLength) FinishRender();
    }
}