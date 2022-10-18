using UnityEngine;
public class ConversationTrigger : MonoBehaviour{
    public void TriggerConversation(){
        FindObjectOfType<PlayerController>().ChangeInConversation(true);
        //Fetch all the values and then start the tree
    }
    public void StartTree(){
        
    }
    
}