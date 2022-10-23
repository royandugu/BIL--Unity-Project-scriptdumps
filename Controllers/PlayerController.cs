using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Animator animController;
    private string animationState;
    private float speed=6,xPressValue,yPressValue;
    public byte turnDir=2,phaseValue=1; 
    private void Awake() {
        playerSprite=GetComponent<SpriteRenderer>();    
        animController=GetComponent<Animator>();
        animController.speed=0.5f;
    }
    private void Update()
    {
        xPressValue=Input.GetAxisRaw("Horizontal");
        yPressValue=Input.GetAxisRaw("Vertical");
        AnimatePlayer();
        MovePlayer();
      
    }
    public void ChooseAnimationState(string newState){
        if(animationState==newState) return;
        else {
            animController.Play(newState);
        }
        animationState=newState;    
    }
    public void FlipPlayer(bool condition){
        if(condition){
            if(xPressValue<0) playerSprite.flipX=true;
            else playerSprite.flipX=false;
        }
        else playerSprite.flipX=true;
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
                FlipPlayer(true);
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
                    FlipPlayer(true);
                    ChooseAnimationState("walkX");
                }
            }
        }
    }
    public void MovePlayer(){
        transform.position+=new Vector3(xPressValue,yPressValue,0)*Time.deltaTime*speed;
    }

}
