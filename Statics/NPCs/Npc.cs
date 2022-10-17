using System.IO;
using UnityEngine;
public class NPC:MonoBehaviour{
    [System.Serializable]
    public class Sharon{
        public string[] phaseOne;
        public string[] phaseTwo;
    }
    private void Start() {
        string jsonString=File.ReadAllText("Assets/Scripts/Statics/CharacterConversationScripts/characterDialogues.json");
        Sharon sharonDialogs=JsonUtility.FromJson<Sharon>(jsonString);
        Debug.Log(sharonDialogs.phaseOne[0]);               
    }
}