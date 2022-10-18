using System.IO;
using UnityEngine;
public class NPC{
    public class One{
        public Sharon Sharon;
    }
    [System.Serializable]
    public class Sharon{
            public string[] phaseOne;
            public string[] phaseTwo;
    }
    public void GetText(){
        string jsonString=File.ReadAllText("Assets/Scripts/Statics/CharacterConversationScripts/characterDialogues.json");
        One dialogs=JsonUtility.FromJson<One>(jsonString);   
        Debug.Log(dialogs.Sharon.phaseOne[0]);           
    }
}