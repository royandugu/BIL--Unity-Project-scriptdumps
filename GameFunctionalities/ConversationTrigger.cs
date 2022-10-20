using UnityEngine;
public class ConversationTrigger : MonoBehaviour{
    public void TriggerConversation(){
        FindObjectOfType<SceneManagerGame>().LoadConversationScene();
    }
}