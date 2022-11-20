using System;
using UnityEngine;
class RadialTrigger : MonoBehaviour {
    [SerializeField]
    private bool isPrimary;
    [SerializeField]
    private float[] talkPoints;
    Npc npc;
    private UIControllers uiController;
    private CurrentNpcHolder currentNpcHolder;
    private byte phaseNumber,npcNumber;
    private PlayerController player;
    private Transform playerTransform;
    private float xCord1,yCord1,distanceSquare;
    private void Start() {
        player=GameObject.FindObjectOfType<PlayerController>();
        playerTransform=player.transform;
        uiController=FindObjectOfType<UIControllers>();
        currentNpcHolder=FindObjectOfType<CurrentNpcHolder>();
        try{
            npc=currentNpcHolder.npc;
            npc.npcNumber=npcNumber;
            npc.DecideCanTalk();
        }
        catch(Exception){
            npc=new Npc(isPrimary,talkPoints);
            npc.npcNumber=npcNumber;
            npc.DecideCanTalk();
        }
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