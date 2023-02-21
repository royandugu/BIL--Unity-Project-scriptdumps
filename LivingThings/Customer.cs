using UnityEngine;
public class Customer : MonoBehaviour {
    private void Start() {
        transform.position=new Vector3(0,0,0); //Generation point
    }
    private void Update() {
        transform.position-=new Vector3(1,0,0)*Time.deltaTime*5;
    }
}