using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 transPos;
    private void Awake(){
        playerTransform=GameObject.FindWithTag("Player").transform;    
    }
    private void LateUpdate() {
        if(!playerTransform) return;
        if(playerTransform.position.x>=-7.83){
            transPos.x=-7.83f;
            YChecks();
        }
        else if(playerTransform.position.x<=-23.64){
            transPos.x=-23.64f;
            YChecks();
        }
        else if(playerTransform.position.y>=5.3){
            transPos.y=5.3f;
            XChecks();
        }
        else if(playerTransform.position.y<=-28){
            transPos.y=-28f;
            XChecks();
        }
        else{
            transPos.x=playerTransform.position.x;
            transPos.y=playerTransform.position.y;
        }
        transPos.z=-1;
        transform.position=transPos;
    }
    public void YChecks(){
        if(playerTransform.position.y>=5.3) transPos.y=5.3f;
        else if(playerTransform.position.y<=-28) transPos.y=-28f;
        else transPos.y=playerTransform.position.y;
    }
    public void XChecks(){
        if(playerTransform.position.x<=-23.64) transPos.x=-23.64f;
        if(playerTransform.position.x>=5.3) transPos.x=5.3f;
        else transPos.x=playerTransform.position.x;
    }
}
