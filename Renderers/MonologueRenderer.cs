using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class MonologueRenderer:MonoBehaviour{
    //Unity Built ins
    private void Start() {
        //Yo location mah paxxi pani monologues haru auxa
        if(Game.playMonologue){
            string monologue=GetMonologueInfo();
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
        //Render monologue text my text
        yield return new WaitForSeconds(.1f); 
    }

}