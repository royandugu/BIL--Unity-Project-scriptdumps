using UnityEngine;
class PeopleRadialTrigger : MonoBehaviour {
    [SerializeField]
    private bool isPrimary;
    [SerializeField]
    private float[] talkPoints;
    Npc npc;
    private UIControllers uiController;
    private CurrentNpcHolder currentNpcHolder;
    private byte phaseNumber,npcNumber;
    private PlayerController player;
    private float xCord1,yCord1,distanceSquare;
    private void Start() {
        player=GameObject.FindObjectOfType<PlayerController>(); //We can acess the co-ordinates from the Player class
        uiController=FindObjectOfType<UIControllers>();
        currentNpcHolder=FindObjectOfType<CurrentNpcHolder>();
        try{
            npc=currentNpcHolder.npc;
            npc.npcNumber=npcNumber;
            npc.DecideCanTalk();
        }
        catch(System.Exception){
            npc=new Npc(isPrimary,talkPoints);
            npc.npcNumber=npcNumber;
            npc.DecideCanTalk();
        }
    }
    private void Update() {
        xCord1=Player.xCord;
        yCord1=Player.yCord;
        float distanceSquare=(xCord1-transform.position.x)*(xCord1-transform.position.x)+(yCord1-transform.position.y)*(yCord1-transform.position.y);
        if(distanceSquare<=8 && npc.canTalk==true) {
            uiController.MakeVisible(0);
            currentNpcHolder.SetNpc(npc);
        }
        else uiController.MakeInvisible(0);
    }
}