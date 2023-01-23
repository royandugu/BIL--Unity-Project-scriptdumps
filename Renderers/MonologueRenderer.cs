using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class MonologueRenderer:MonoBehaviour{
    [SerializeField]
    private TMPro.TMP_Text monologueText;
    private string monologue;
    private int monologueLength,index=0;
    private bool startFlag=false;
    //Unity Built ins
    private void Start() {
        //Yo location mah paxxi pani monologues haru auxa
        if(Game.playMonologue){
            monologue=GetMonologueInfo();
            Debug.Log(monologue);
            monologueLength=monologue.Length;
            StartCoroutine(RenderMonologue(monologue.ElementAt(index)));

            //Animate the fade
        }
    }
    //User defined functions
    public string GetMonologueInfo(){
        string jsonString=Resources.Load<TextAsset>("CharacterConversationScripts/monologues").text;
        MonologueInfo value=new MonologueInfo();
        IDictionary<string,MonologueInfo> parsed=new Dictionary<string,MonologueInfo>();
        parsed=JsonConvert.DeserializeObject<IDictionary<string,MonologueInfo>>(jsonString);
        parsed.TryGetValue("monologues",out value);
        return value.initials[(int)Player.selfConv++];
    }
    public System.Collections.IEnumerator RenderMonologue(char letter){
        startFlag=true;
        yield return new WaitForSeconds(.1f); 
        monologueText.text+=letter;
        index++;
        if(index==monologueLength) yield break;
        StartCoroutine(RenderMonologue(monologue.ElementAt(index)));       
    }

}