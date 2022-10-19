using UnityEngine;
class RadialTrigger : MonoBehaviour {
    public byte npcNumber;
    private PlayerController player;
    private Transform playerTransform;
    private float xCord1,yCord1;
    private void Start() {
        player=GameObject.FindObjectOfType<PlayerController>();
        playerTransform=player.transform;
    }
    private void Update() {
        xCord1=playerTransform.position.x;
        yCord1=playerTransform.position.y;
        float distanceSquare=(xCord1-transform.position.x)*(xCord1-transform.position.x)+(yCord1-transform.position.y)*(yCord1-transform.position.y);
        if(distanceSquare<=8) {
            FindObjectOfType<UIControllers>().MakeVisible(0);
            FindObjectOfType<CurrentNpcHolder>().SetNpcNumber(npcNumber);
        }
        else FindObjectOfType<UIControllers>().MakeInvisible(0);
    }
}