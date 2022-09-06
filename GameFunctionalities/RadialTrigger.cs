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
        else FindObjectOfType<UIControllers>().MakeInvisible(0);
    }
    public void ShowOptions(){
        FindObjectOfType<UIControllers>().MakeVisible(0);
    }
    public void TriggerConversation(){
        
    }
}