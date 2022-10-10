using System;
using System.IO;
using UnityEngine;
public class ConversationFetcher:MonoBehaviour
{
    public void GetConversation(NPC n){
        string jsonFile=File.ReadAllText("Assets/Scripts/Statics/CharacterConversationScripts/"+n.GetName()+".json");
        var compInstance = (Component)Activator.CreateInstance(n.GetType());
        // compInstance=JsonUtility.FromJson(jsonFile,compInstance.GetType()) ??; 
    }
    private void Start() {
        Sharon s;
        GameObject go=new GameObject("Sharon");
        s=go.AddComponent<Sharon>();
        GetConversation(s);
    }
}
