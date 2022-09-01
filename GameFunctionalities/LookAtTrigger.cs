using UnityEngine;
class LookAtTrigger : MonoBehaviour {
    private Transform playerTransform;
    private float xCord,yCord;
    private void Start() {
        playerTransform=GameObject.FindWithTag("Player").transform;
    }
    private void Update() {
        xCord=playerTransform.position.x;
        yCord=playerTransform.position.y;
        float distanceSquare=(xCord-transform.position.x)*(xCord-transform.position.x)+(yCord-transform.position.y)*(yCord-transform.position.y);
        if(distanceSquare<=9) ShowOptions();
        else return;
    }
    public void ShowOptions(){
        //Unity text UI
        Debug.Log("Player can trigger a conversation with the NPC");
    }
    public void TriggerConversation(){
        //Hop to the conversation screen, so all objects will automatically get destroyed except for player hmm
    }
}