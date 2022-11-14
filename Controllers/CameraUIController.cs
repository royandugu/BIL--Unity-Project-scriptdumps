using UnityEngine;
public class CameraUIController: MonoBehaviour {
    [SerializeField]
    private TMPro.TMP_Text textTarget;
    private void Update() {
        textTarget.text=Player.mentalHealth.ToString();
    }
}