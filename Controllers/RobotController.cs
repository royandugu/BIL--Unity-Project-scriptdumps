using UnityEngine;

public class RobotController : MonoBehaviour {
    [SerializeField]
    private float maxValue,minValue;
    [SerializeField]
    private byte incValue;
    [SerializeField]
    private bool flag;
    [SerializeField]
    private string initialPosName;
    private AnimationController aController;
    private Animator animator;
    public void IncrementPosition(Vector3 value){
        transform.position+=value*Time.deltaTime*3;
    }
    public void DecrementPosition(Vector3 value){
        transform.position-=value*Time.deltaTime*3;
    }
    private void Start() {
        animator=GetComponent<Animator>();
        aController=new AnimationController(initialPosName);
        animator.speed=0.8f;
    }
    private void Update() {
        if(incValue==0){
            if(transform.position.x<=minValue) flag=false;
            else if(transform.position.x>=maxValue) flag=true;
            if(flag) {
                aController.ChooseAnimationState(animator,"walkXRobo");
                this.gameObject.GetComponent<SpriteRenderer>().flipX=true;
                DecrementPosition(new Vector3(1,0,0));
            }
            else {
                aController.ChooseAnimationState(animator,"walkXRobo");
                this.gameObject.GetComponent<SpriteRenderer>().flipX=false;
                IncrementPosition(new Vector3(1,0,0));
            }
        }
        else if(incValue==1){
            if(transform.position.y<=minValue) flag=false;
            else if(transform.position.y>=maxValue) flag=true;
            if(flag) {
                aController.ChooseAnimationState(animator,"walkYNegRobo");
                DecrementPosition(new Vector3(0,1,0));
            }
            else {
                aController.ChooseAnimationState(animator,"walkYPosRobo");
                IncrementPosition(new Vector3(0,1,0));
            }
        }
    }    
}