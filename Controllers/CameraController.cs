using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform playerTransform;
    private Vector3 transPos;

    private void LateUpdate() {
        if(!playerTransform) return;
        transPos=playerTransform.position;
        transPos.x=playerTransform.position.x;
        transPos.y=playerTransform.position.y;
        transPos.z=-1;
        transform.position=transPos;
    }
}
