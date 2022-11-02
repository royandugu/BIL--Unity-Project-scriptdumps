using UnityEngine;
public class PlayerChoiceClickTrigger:MonoBehaviour{
    public bool firstChoice=false,secondChoice=false;
    public void FirstClick(){
        secondChoice=false;
        firstChoice=true;
    }
    public void SecondClick(){
        firstChoice=false;
        secondChoice=true;
    }
}