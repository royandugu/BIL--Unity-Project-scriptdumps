using UnityEngine;
public class PlayerChoiceClickTrigger:MonoBehaviour{
    private bool firstChoice=false,secondChoice=false;
    public void FirstClick(){
        firstChoice=true;
    }
    public void SecondClick(){
        secondChoice=true;
    }
}