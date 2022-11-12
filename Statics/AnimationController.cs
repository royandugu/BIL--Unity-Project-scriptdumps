using UnityEngine;
public class AnimationController{
    private string animationState;
    public AnimationController(string animationState){
        this.animationState=animationState;
    }
    public void ChooseAnimationState(Animator animController,string newState){
        if(animationState==newState) return;
        else {
            animController.Play(newState);
        }   
        animationState=newState; 
    }
}