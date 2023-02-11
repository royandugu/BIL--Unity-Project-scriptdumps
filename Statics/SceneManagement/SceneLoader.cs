using UnityEngine.SceneManagement; 

public class SceneLoader
{
    public enum Scenes{
        GameScene,
        LoadGame,
        MainMenu,
        StartMonologue,
        Settings,
        ConversationScene,
        PBedRoom,
        PlayerShop
    }
    public static void LoadScene(Scenes sceneName){
        SceneManager.LoadScene(sceneName.ToString());
    }
    public static string GetCurrentScene(){
        return SceneManager.GetActiveScene().name;
    }
}
