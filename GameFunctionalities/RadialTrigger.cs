using UnityEngine;
class RadialTrigger : MonoBehaviour {
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
        else {
            FindObjectOfType<UIControllers>().MakeInvisible(0);
            return;
        }
    }
    public void ShowOptions(){
        FindObjectOfType<UIControllers>().MakeVisible(0);
        Debug.Log("Player can trigger a conversation with the NPC");
    }
    public void TriggerConversation(){
        //Hop to the conversation screen, so all objects will automatically get destroyed except for player hmm
    }
}