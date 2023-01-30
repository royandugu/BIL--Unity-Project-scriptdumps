using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Animator animController;
    private string animationState;
    private AnimationController aController;
    private float speed=4,xPressValue,yPressValue;
    public byte turnDir=2,phaseValue=1,collisionTurnDir=2;
    private bool hasCollided=false;

    //Unity built in functions
     private void Awake() {
        playerSprite=GetComponent<SpriteRenderer>();    
        animController=GetComponent<Animator>();
        aController=new AnimationController("idleX");
        
        animController.speed=0.5f;
        
        if(BasicGameDetails.isOld){
            string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "GameInfo");
            string jsonString=System.IO.File.ReadAllText(filePath);
            GameSaver.SaveFormat sf=JsonUtility.FromJson<GameSaver.SaveFormat>(jsonString);
            Player.xCord=sf.PlayerInfo.xCord;
            Player.yCord=sf.PlayerInfo.yCord;
            Player.mentalHealth=sf.PlayerInfo.mentalHealth;
            Player.pSConv=sf.PlayerInfo.pSConv;
            Player.sSConv=sf.PlayerInfo.sSConv;
        }
        else if(!BasicGameDetails.isTempOld && !BasicGameDetails.isOld){
            Player.xCord=0;
            Player.yCord=0;
            Player.mentalHealth=50;
            Player.pSConv=0;
            Player.sSConv=0;
        }
        transform.position=new Vector3(Player.xCord,Player.yCord,0);
        Debug.Log(Player.mentalHealth);
    }
    private void Update()
    {
        if(Player.canMove){
            if(hasCollided){
                xPressValue=0;
                yPressValue=0;
            }
            else{
                GetUserInputs();
                AnimatePlayer();
                MovePlayer();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        hasCollided=true;
        collisionTurnDir=turnDir;
    }
    private void OnCollisionStay2D(Collision2D other) {
        GetUserInputs();
        if(collisionTurnDir==0){
            if(yPressValue==-1){
                hasCollided=true;
                aController.ChooseAnimationState(animController,"idleYPos");
            }
            else hasCollided=false;
        }
        else if(collisionTurnDir==1){
            if(yPressValue==1){
                hasCollided=true;
                aController.ChooseAnimationState(animController,"idleYNeg");
            }
            else hasCollided=false;
        }
        else{
            if(playerSprite.flipX){
                if(xPressValue==-1) {
                    hasCollided=true;
                    aController.ChooseAnimationState(animController,"idleX");
                    playerSprite.flipX=true;
                }
                else hasCollided=false;
            }
            else{
                if(xPressValue==1) {
                    hasCollided=true;
                    aController.ChooseAnimationState(animController,"idleX");
                }
                else hasCollided=false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        hasCollided=false;
    }
    //User-defined
    public void GetUserInputs(){
        xPressValue=Input.GetAxisRaw("Horizontal");
        yPressValue=Input.GetAxisRaw("Vertical");
        if(xPressValue!=0)yPressValue=0;
        if(yPressValue!=0)xPressValue=0;
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
            if(turnDir==0) aController.ChooseAnimationState(animController,"idleYPos");
            else if(turnDir==1) aController.ChooseAnimationState(animController,"idleYNeg");
            else if(turnDir==2) aController.ChooseAnimationState(animController,"idleX");
        } 
        else{
            if(xPressValue!=0 && yPressValue!=0){
                turnDir=2;
                FlipPlayer(true);
                aController.ChooseAnimationState(animController,"walkX");    
            }
            else{
                if(yPressValue>0){
                    turnDir=1;
                    aController.ChooseAnimationState(animController,"walkYNeg");
                }
                if(yPressValue<0){
                    turnDir=0;
                    aController.ChooseAnimationState(animController,"walkYPos");
                }
                if(yPressValue==0){
                    turnDir=2;
                    FlipPlayer(true);
                    aController.ChooseAnimationState(animController,"walkX");
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
