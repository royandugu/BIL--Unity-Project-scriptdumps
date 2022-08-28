using UnityEngine.SceneManagement; 

public class SceneLoader
{
    public enum Scenes{
        GameScene,
        LoadGame,
        MainMenu,
        PlayerSelectScene,
        Settings
    }
    public static void LoadScene(Scenes sceneName){
        SceneManager.LoadScene(sceneName.ToString());
    }
}
