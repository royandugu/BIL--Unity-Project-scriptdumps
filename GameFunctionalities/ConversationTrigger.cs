using UnityEngine;
class ConversationTrigger:MonoBehaviour{
    public void TriggerConversation(){
        FindObjectOfType<PlayerController>().ChangeInConversation(true);
    }
}