using System.IO;
using UnityEngine;
public class NPC:MonoBehaviour{
    public class PhaseOneContainer{
        public NpcInfo[] phaseOne;
    }
    [System.Serializable]
    public class NpcInfo{
        public string name;
        public string[] dialogs;
        public int[] tree;
    }
    public string GetName(string name){
        return name;
    }
    public string[] GetDialog(string[] dialogs){
        return dialogs;
    }
    public int[] GetTree(int[] tree){
        return tree;
    }
    public void GetInfo(int npcNo,int infoFlag){
        string jsonString=File.ReadAllText("Assets/Scripts/Statics/CharacterConversationScripts/characterDialogues.json");
        PhaseOneContainer npcInfo=JsonUtility.FromJson<PhaseOneContainer>(jsonString);   
        if(infoFlag==0) GetName(npcInfo.phaseOne[npcNo].name);
        else if(infoFlag==1) GetDialog(npcInfo.phaseOne[npcNo].dialogs);
        else if(infoFlag==2) GetTree(npcInfo.phaseOne[npcNo].tree);
    }
}