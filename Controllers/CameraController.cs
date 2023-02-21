using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float leftXLimit,rightXLimit,topYLimit,bottomYLimit;
    private Transform playerTransform;
    private Vector3 transPos;
    //Unity built-in functions
    private void Awake(){
        playerTransform=GameObject.FindWithTag("Player").transform;   //This is to be done because hamro player choices haru agadi bata auxa 
    }
    private void LateUpdate() {
        if(!playerTransform) return;
        if(playerTransform.position.x>=rightXLimit){
            transPos.x=rightXLimit;
            YChecks();
        }
        else if(playerTransform.position.x<=leftXLimit){
            transPos.x=leftXLimit;
            YChecks();
        }
        else if(playerTransform.position.y>=topYLimit){
            transPos.y=topYLimit;
            XChecks();
        }
        else if(playerTransform.position.y<=bottomYLimit){
            transPos.y=bottomYLimit;
            XChecks();
        }
        else{
            transPos.x=playerTransform.position.x;
            transPos.y=playerTransform.position.y;
        }
        transPos.z=-1;
        transform.position=transPos;
    }
    //User defined functions
    public void YChecks(){
        if(playerTransform.position.y>=topYLimit) transPos.y=topYLimit;
        else if(playerTransform.position.y<=bottomYLimit) transPos.y=bottomYLimit;
        else transPos.y=playerTransform.position.y;
    }
    public void XChecks(){
        if(playerTransform.position.x<=leftXLimit) transPos.x=leftXLimit;
        if(playerTransform.position.x>=rightXLimit) transPos.x=rightXLimit;
        else transPos.x=playerTransform.position.x;
    }
}
