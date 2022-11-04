using UnityEngine;
public class CurrentNpcHolder : MonoBehaviour {
    public Npc npc;
    public void SetNpc(Npc npc){
        this.npc=npc;
    }
    private void Update() {
        if(SceneLoader.GetCurrentScene()=="ConversationScene" || SceneLoader.GetCurrentScene()=="GameScene") DontDestroyOnLoad(this.gameObject);
        else Destroy(this.gameObject);
    }
}