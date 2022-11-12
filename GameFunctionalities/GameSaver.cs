using UnityEngine;

public class GameSaver:MonoBehaviour{
    [System.Serializable]
    public class PlayerInfo{
        public float xCord,yCord,mentalHealth,noOfConv;
        public PlayerInfo(){
            this.xCord=Player.xCord;
            this.yCord=Player.yCord;
            this.mentalHealth=Player.mentalHealth;
            this.noOfConv=Player.noOfConv;
        }
    }
    [System.Serializable]
    public class SaveFormat{
        public PlayerInfo PlayerInfo=new PlayerInfo();
    }
    public void SaveGame(){
        SaveFormat sf=new SaveFormat();
        string data=JsonUtility.ToJson(sf);
        System.IO.File.WriteAllText("Assets/Resources/JsonFiles/GameInfo.json",data);
    }
    
}
