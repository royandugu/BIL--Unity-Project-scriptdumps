using UnityEngine;
class RadialTrigger : MonoBehaviour {
    [SerializeField]
    private bool canTalk;
    Npc npc;
    private UIControllers uiController;
    private CurrentNpcHolder currentNpcHolder;
    public byte npcNumber;
    public byte phaseNumber;
    private PlayerController player;
    private Transform playerTransform;
    private float xCord1,yCord1;
    private void Start() {
        player=GameObject.FindObjectOfType<PlayerController>();
        playerTransform=player.transform;
        uiController=FindObjectOfType<UIControllers>();
        currentNpcHolder=FindObjectOfType<CurrentNpcHolder>();
        if(currentNpcHolder.npc==null || currentNpcHolder.npc.npcNumber!=npc.npcNumber) npc=new Npc(canTalk);
        else npc=currentNpcHolder.npc;
    }
    private void Update() {
        xCord1=playerTransform.position.x;
        yCord1=playerTransform.position.y;
        float distanceSquare=(xCord1-transform.position.x)*(xCord1-transform.position.x)+(yCord1-transform.position.y)*(yCord1-transform.position.y);
        if(distanceSquare<=8 && npc.canTalk==true) {
            uiController.MakeVisible(0);
            currentNpcHolder.SetNpc(npc);
        }
        else uiController.MakeInvisible(0);
    }
}