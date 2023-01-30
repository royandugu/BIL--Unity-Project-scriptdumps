using UnityEngine;
public class BackgroundFader : MonoBehaviour {
    [SerializeField]
    private string idleAnimationName,fadeAnimationName;
    private Animator animController;
    private AnimationController aController;
    //Built ins
    private void Awake() {
        animController=GetComponent<Animator>();
        aController=new AnimationController(idleAnimationName);
    }  
    private void Update() {
        if(Game.fadeStart && Game.fadeIndex==0) {
            Game.fadeEnd=false;
            aController.ChooseAnimationState(animController,fadeAnimationName);
            Game.fadeStart=false;
            Game.fadeIndex++;
        }
    }
    //User defined
    public void OnFadeEnd(){
        Game.resetMonologue=true;
        Game.playMonologue=true;
        Game.fadeEnd=true;
        Game.fadeStart=false;
    }
}