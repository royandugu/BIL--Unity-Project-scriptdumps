using UnityEngine;
using static GameSaver;
public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Animator animController;
    private string animationState;
    private float speed=6,xPressValue,yPressValue;
    public byte turnDir=2,phaseValue=1;
    private bool hasCollided=false;

    //Unity built in functions
    private void Awake() {
        playerSprite=GetComponent<SpriteRenderer>();    
        animController=GetComponent<Animator>();
        if(BasicGameDetails.isOld){
            string jsonString=Resources.Load<TextAsset>("JsonFiles/GameInfo").text;
            SaveFormat sf=JsonUtility.FromJson<SaveFormat>(jsonString);
            Player.xCord=sf.PlayerInfo.xCord;
            Player.yCord=sf.PlayerInfo.yCord;
            Player.mentalHealth=sf.PlayerInfo.mentalHealth;
            Player.noOfConv=sf.PlayerInfo.noOfConv;
        }
        else{
            Player.xCord=0;
            Player.yCord=0;
            Player.mentalHealth=100;
            Player.noOfConv=0;
        }
        animController.speed=0.5f;
        transform.position=new Vector3(Player.xCord,Player.yCord,0);
    }
    private void Update()
    {
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
    private void OnCollisionEnter2D(Collision2D other) {
        hasCollided=true;
    }
    private void OnCollisionStay2D(Collision2D other) {
        GetUserInputs();
        if(turnDir==0){
            if(yPressValue!=-1) hasCollided=false; 
        }
        else if(turnDir==1){
            if(yPressValue!=1) hasCollided=false;
        }
        else{
            if(playerSprite.flipX){
                if(xPressValue!=-1) hasCollided=false;
            }
            else{
                if(xPressValue!=1) hasCollided=false;
            }
        }
    }
    //User-defined
    public void GetUserInputs(){
        xPressValue=Input.GetAxisRaw("Horizontal");
        yPressValue=Input.GetAxisRaw("Vertical");
        if(xPressValue!=0)yPressValue=0;
        if(yPressValue!=0)xPressValue=0;
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
