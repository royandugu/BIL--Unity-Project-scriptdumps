using UnityEngine;

public class GameSaver:MonoBehaviour{
    [System.Serializable]
    public class PlayerInfo{
        public float xCord,yCord,mentalHealth,pSConv,sSConv;
        public PlayerInfo(){
            this.xCord=Player.xCord;
            this.yCord=Player.yCord;
            this.mentalHealth=Player.mentalHealth;
            this.pSConv=Player.pSConv;
            this.sSConv=Player.sSConv;
        }
    }
    [System.Serializable]
    public class SaveFormat{
        public PlayerInfo PlayerInfo=new PlayerInfo();
    }
    public void SaveGame(){
        SaveFormat sf=new SaveFormat();
        string data=JsonUtility.ToJson(sf);
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "GameInfo");
        System.IO.File.WriteAllText(filePath,data);
    }
    
}
