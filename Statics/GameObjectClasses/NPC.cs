using System.Dynamic;

public class Npc{
    public dynamic fetcherObj;
    public bool canTalk,isPrimary;
    public float[] talkPoints;
    public byte npcNumber;
    private float comparator;
    public Npc(bool isPrimary,float[] talkPoints){
        this.isPrimary=isPrimary;
        this.talkPoints=talkPoints;
    }
    public void DecideCanTalk(){
        if(isPrimary) comparator=Player.pSConv;
        else comparator=Player.sSConv;
        foreach(float number in talkPoints){
            if(number==comparator){
                canTalk=true;
                return;
            }  
            else canTalk=false;      
        }
    }
}