using UnityEngine;

public class SceneManagerTitle:MonoBehaviour{
    public void LoadMonologue(){
        SceneLoader.LoadScene(SceneLoader.Scenes.StartMonologue);
    }
    public void LoadOldGame(){
        BasicGameDetails.isOld=true;
        SceneLoader.LoadScene(SceneLoader.Scenes.GameScene);
    }
    public void LoadNewGame(){
        BasicGameDetails.isOld=false;
        BasicGameDetails.isTempOld=false;
        SceneLoader.LoadScene(SceneLoader.Scenes.GameScene); 
    } 
    public void LoadSettings(){
        SceneLoader.LoadScene(SceneLoader.Scenes.Settings);
    }
}