using UnityEngine;
class RadialTrigger : MonoBehaviour {
    public int npcNumber;
    private PlayerController player;
    private Transform playerTransform;
    private float xCord1,yCord1;
    private void Start() {
        player=GameObject.FindObjectOfType<PlayerController>();
        playerTransform=player.transform;
    }
    private void Update() {
        xCord1=playerTransform.position.x;
        yCord1=playerTransform.position.y;
        float distanceSquare=(xCord1-transform.position.x)*(xCord1-transform.position.x)+(yCord1-transform.position.y)*(yCord1-transform.position.y);
        if(distanceSquare<=8) ShowOptions();
        else FindObjectOfType<UIControllers>().MakeInvisible(0);
        if(player.inConversation && !player.called) GetPlayerFixWatch();   
    }
    public void GetPlayerFixWatch(){
        player.called=true;
        float xCord2=transform.position.x;
        float yCord2=transform.position.y;
        if(yCord1==yCord2){
            if(xCord1>xCord2) player.FlipPlayer(false);
        }
        else if(yCord1>yCord2){
            if(yCord1>yCord2+1.3) player.ChooseAnimationState("idleYPos");
            else if(xCord1>xCord2) player.FlipPlayer(false);
        }   
        else player.ChooseAnimationState("idleYNeg");
        FindObjectOfType<ConversationTrigger>().TriggerConversation();
    }
    public void ShowOptions(){
        FindObjectOfType<UIControllers>().MakeVisible(0);
    }
}