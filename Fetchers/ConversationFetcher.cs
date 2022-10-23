using System.IO;
using UnityEngine;
public class ConversationFetcher:MonoBehaviour
{
    private byte pValue;
    public class PhaseOneContainer{
        public NpcInfo[] phaseOne;
    }

    [System.Serializable]
    public class NpcInfo{
        public string name;
        public string[] dialogs;
        public byte[] tree;
    }
    private void Start() {
        pValue=FindObjectOfType<PlayerController>().phaseValue;
        if(pValue==1){
            string jsonString=File.ReadAllText("Assets/Scripts/Statics/CharacterConversationScripts/lightLineMonologue.json");
            PhaseOneContainer npcInfo=JsonUtility.FromJson<PhaseOneContainer>(jsonString);   
        
        }
    }
}
