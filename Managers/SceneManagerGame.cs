using UnityEngine;

public class SceneManagerGame : MonoBehaviour
{
    public void LoadMainMenu(){
        SceneLoader.LoadScene(SceneLoader.Scenes.MainMenu);
    }
}
