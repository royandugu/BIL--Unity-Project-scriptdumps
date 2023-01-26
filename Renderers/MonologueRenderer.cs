using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class MonologueRenderer:MonoBehaviour{
    [SerializeField]
    private TMPro.TMP_Text monologueText;
    private string monologue;
    private int monologueLength,index=0;
    private bool hasNotStarted=true;
    //Unity Built ins
    private void Start() {
        //Yo location mah paxxi pani monologues haru auxa
        
    }
    private void Update() {
        if(Game.resetMonologue) monologueText.text=" ";
        if(Game.playMonologue && hasNotStarted) FetchAndPlay();
        if(Game.playMonologue && hasNotStarted && Game.fadeEnd) FetchAndPlay();
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
        hasNotStarted=false;
        yield return new WaitForSeconds(.1f); 
        monologueText.text+=letter;
        index++;
        if(index==monologueLength) {
            Game.fadeStart=true;
            hasNotStarted=true;
            index=0;
            yield break;
        }
        StartCoroutine(RenderMonologue(monologue.ElementAt(index)));       
    }

}