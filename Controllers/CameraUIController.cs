using UnityEngine;
public class CameraUIController: MonoBehaviour {
    [SerializeField]
    private TMPro.TMP_Text textTarget;
    [SerializeField]
    private GameObject[] toDestroy; 
    private void Update() {
        if(SceneLoader.GetCurrentScene()=="GameScene") {
            DontDestroyOnLoad(this);
            textTarget.text=Player.mentalHealth.ToString();
        }
        else if(SceneLoader.GetCurrentScene()=="ConversationScene"){
            for(int i=0;i<toDestroy.Length;i++){
                Destroy(toDestroy[i]);
            }
        }
        else Destroy(this);
    }
}