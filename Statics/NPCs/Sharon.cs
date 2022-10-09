public class Sharon:Npc{
    Sharon():base("Sharon"){
        return;
    }
    private string[] phaseOne;
    private string[] phaseTwo;
    private string[] phaseThree;
    public string GetText(int phaseValue, int index){
        if(phaseValue==1) return phaseOne[index];
        else if(phaseValue==2) return phaseTwo[index];
        else return phaseThree[index];
    }
}