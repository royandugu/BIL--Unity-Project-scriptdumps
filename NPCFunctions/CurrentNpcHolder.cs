using UnityEngine;
public class CurrentNpcHolder : MonoBehaviour {
    public byte npcNumber;
    public byte phaseNumber;
    public void SetNpcNumber(byte number){
        if(npcNumber==number) return;
        else npcNumber=number;
        Debug.Log(npcNumber);
    }
    public void SetPhaseNumber(byte number){
        phaseNumber=number;
    }
    private void Update() {
        if(SceneLoader.GetCurrentScene()=="ConversationScene" || SceneLoader.GetCurrentScene()=="GameScene") DontDestroyOnLoad(this.gameObject);
        else Destroy(this.gameObject);
    }
}