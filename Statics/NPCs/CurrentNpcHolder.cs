using UnityEngine;
public class CurrentNpcHolder : MonoBehaviour {
    public byte npcNumber;
    public void SetNpcNumber(byte number){
        if(npcNumber==number) return;
        else npcNumber=number;
        Debug.Log(npcNumber);
    }
    private void Update() {
        if(SceneLoader.GetCurrentScene()=="ConversationScene" || SceneLoader.GetCurrentScene()=="GameScene") DontDestroyOnLoad(this.gameObject);
        else Destroy(this.gameObject);
    }
}