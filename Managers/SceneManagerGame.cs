using UnityEngine;

public class SceneManagerGame : MonoBehaviour
{
    public void LoadMainMenu(){
        SceneLoader.LoadScene(SceneLoader.Scenes.MainMenu);
    }
    public void LoadConversationScene(){
        SceneLoader.LoadScene(SceneLoader.Scenes.ConversationScene);
    }
    public void LoadShopScene(){
        SceneLoader.LoadScene(SceneLoader.Scenes.PlayerShop);
    }
}
