using System.IO;
using UnityEngine;

public class ConversationFetcher:MonoBehaviour
{
    public void GetConversation(/*Npc n*/){
        string jsonFile=File.ReadAllText("Assets/Scripts/Statics/CharacterConversationScripts/"+/*n.name*+*/".json");
        /*  1. Get the class (GetType or GetComponent)
            2. GotClass obj=JsonUtility.FromJson<GotClass>(jsonFile)
        */
    }
}
