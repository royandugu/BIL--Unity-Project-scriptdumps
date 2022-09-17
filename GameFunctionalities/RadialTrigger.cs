using UnityEngine;
class RadialTrigger : MonoBehaviour {
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
        if(distanceSquare<=9) ShowOptions();
        else FindObjectOfType<UIControllers>().MakeInvisible(0);
        if(player.inConversation && !player.called) GetPlayerFixWatch();   
    }
    public void GetPlayerFixWatch(){
        player.called=true;
        float xCord2=transform.position.x;
        float yCord2=transform.position.y;
        if(xCord1==xCord2){
            if(yCord1>yCord2) player.ChooseAnimationState("idleYNeg");
            else if(yCord1<yCord2) player.ChooseAnimationState("idleYPos");
            else player.ChooseAnimationState("idleX");
        }
        else{
            float slope=(yCord2-yCord1)/(xCord2-xCord1);
            Debug.Log(slope);
        }
    }
    public void ShowOptions(){
        FindObjectOfType<UIControllers>().MakeVisible(0);
    }
    public void TriggerConversation(){
        
    }
}