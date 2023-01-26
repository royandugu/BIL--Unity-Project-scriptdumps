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
        if(Game.fadeStart) {
            Game.fadeEnd=false;
            aController.ChooseAnimationState(animController,fadeAnimationName);
            Game.fadeStart=false;
        }
    }
    //User defined
    public void OnFadeEnd(){
        Game.resetMonologue=true;
        Game.fadeEnd=true;
    }
}