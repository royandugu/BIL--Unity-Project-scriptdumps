using UnityEngine;

public class SceneManagerTitle:MonoBehaviour{
    public void LoadPlayerSelectScene(){
        SceneLoader.LoadScene(SceneLoader.Scenes.PlayerSelectScene);
    }
    public void LoadSavedGame(){
        SceneLoader.LoadScene(SceneLoader.Scenes.GameScene);
    }
    public void LoadSettings(){
        SceneLoader.LoadScene(SceneLoader.Scenes.Settings);
    }
}