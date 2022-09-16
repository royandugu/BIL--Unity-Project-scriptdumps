using UnityEngine;
class RadialTrigger : MonoBehaviour {
    private Transform playerTransform;
    private float xCord1,yCord1;
    private void Start() {
        playerTransform=GameObject.FindWithTag("Player").transform;
    }
    private void Update() {
        xCord1=playerTransform.position.x;
        yCord1=playerTransform.position.y;
        float distanceSquare=(xCord1-transform.position.x)*(xCord1-transform.position.x)+(yCord1-transform.position.y)*(yCord1-transform.position.y);
        if(distanceSquare<=9) ShowOptions();
        else FindObjectOfType<UIControllers>().MakeInvisible(0);
        
        GetSlope();   
    }
    public float GetSlope(){
        float xCord2=transform.position.x;
        float yCord2=transform.position.y;
        float slope;
        if(xCord1==xCord2){
            slope=5;
            //Return some value or slope = some value
        }
        else{
            slope=(yCord2-yCord1)/(xCord2-xCord1);
        }
        return slope;
    }
    public void ShowOptions(){
        FindObjectOfType<UIControllers>().MakeVisible(0);
    }
    public void TriggerConversation(){
        
    }
}