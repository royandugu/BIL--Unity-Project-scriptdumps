using UnityEngine;

public class SceneManagerGame : MonoBehaviour
{
    public void LoadMainMenu(){
        SceneLoader.LoadScene(SceneLoader.Scenes.MainMenu);
    }
    public void LoadConversationScene(){
        SceneLoader.LoadScene(SceneLoader.Scenes.ConversationScene);
    }
}
