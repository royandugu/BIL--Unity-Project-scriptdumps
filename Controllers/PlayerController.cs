using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Animator animController;
    
    private string animationState;
    private float speed=6,xPressValue,yPressValue;
    private byte turnDir=2; 
    private bool inConversation=false;
    private bool called=false;
    
    private void Awake() {
        playerSprite=GetComponent<SpriteRenderer>();    
        animController=GetComponent<Animator>();
        animController.speed=0.5f;
    }

    private void Update()
    {
        if(inConversation){
            if(called==true) return;
            else{
                called=true;
            }
        }  
        else{
            called=false;
            xPressValue=Input.GetAxisRaw("Horizontal");
            yPressValue=Input.GetAxisRaw("Vertical");
            AnimatePlayer();
            MovePlayer();
        }
    }
    
    private void ChooseAnimationState(string newState){
        if(animationState==newState) return;
        else {
            animController.Play(newState);
        }
        animationState=newState;    
    }
    
    private void FlipPlayer(){
        if(xPressValue<0) playerSprite.flipX=true;
        else playerSprite.flipX=false;
    }

    public void AnimatePlayer(){
        if(xPressValue==0 && yPressValue==0){
            if(turnDir==0) ChooseAnimationState("idleYPos");
            else if(turnDir==1) ChooseAnimationState("idleYNeg");
            else if(turnDir==2) ChooseAnimationState("idleX");
        } 
        else{
            if(xPressValue!=0 && yPressValue!=0){
                turnDir=2;
                FlipPlayer();
                ChooseAnimationState("walkX");    
            }
            else{
                if(yPressValue>0){
                    turnDir=1;
                    ChooseAnimationState("walkYNeg");
                }
                if(yPressValue<0){
                    turnDir=0;
                    ChooseAnimationState("walkYPos");
                }
                if(yPressValue==0){
                    turnDir=2;
                    FlipPlayer();
                    ChooseAnimationState("walkX");
                }
            }
        }
    }

    public void MovePlayer(){
        transform.position+=new Vector3(xPressValue,yPressValue,0)*Time.deltaTime*speed;
    }

    public void ChangeInConversation(bool value){
        inConversation=value;
    }
}
