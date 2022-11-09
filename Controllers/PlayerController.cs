using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Animator animController;
    private string animationState;
    private float speed=6,xPressValue,yPressValue;
    public byte turnDir=2,phaseValue=1;
    private bool hasCollided=false,isMovingLeft,isMovingRight,isMovingDown,isMovingUp; 
    private void Awake() {
        playerSprite=GetComponent<SpriteRenderer>();    
        animController=GetComponent<Animator>();
        animController.speed=0.5f;
        transform.position=new Vector3(Player.xCord,Player.yCord,0);
    }
    private void Update()
    {
        xPressValue=Input.GetAxisRaw("Horizontal");
        yPressValue=Input.GetAxisRaw("Vertical");
 
        if(xPressValue==1) ChangeMoveFlags(false,true,false,false);
        if(xPressValue==-1) ChangeMoveFlags(true,false,false,false);
        if(yPressValue==1) ChangeMoveFlags(false,false,true,false);
        if(yPressValue==-1) ChangeMoveFlags(false,false,false,true);
        
        if(hasCollided){
            if(turnDir==2){
                if(playerSprite.flipX==true){
                    ChooseAnimationState("idleX");
                    playerSprite.flipX=true;
                    if(isMovingRight) FalsenCollideAnimateAndMove();
                }
                else{
                    ChooseAnimationState("idleX");
                    if(isMovingLeft) FalsenCollideAnimateAndMove();
                }
            }
            else if(turnDir==1){
                ChooseAnimationState("idleYNeg");
                if(isMovingDown) FalsenCollideAnimateAndMove();
            }
            else{
                ChooseAnimationState("idleYPos");
                if(isMovingUp) FalsenCollideAnimateAndMove();
            }
        }
        else{
            AnimatePlayer();
            MovePlayer();
        }
    }
    public void ChangeMoveFlags(bool isMovingLeft, bool isMovingRight, bool isMovingUp, bool isMovingDown){
        this.isMovingLeft=isMovingLeft;
        this.isMovingRight=isMovingRight;
        this.isMovingUp=isMovingUp;
        this.isMovingDown=isMovingDown;
    }
    public void FalsenCollideAnimateAndMove(){
        hasCollided=false;
        AnimatePlayer();
        MovePlayer();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Collider")) hasCollided=true;    
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
        Player.xCord=transform.position.x;
        Player.yCord=transform.position.y;
    }

}
