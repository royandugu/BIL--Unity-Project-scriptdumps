using UnityEngine;
public class ObjectRadialTrigger : MonoBehaviour {
    [SerializeField]
    private string toDisplay;
    [SerializeField]
    private GameObject actionButton;
    [SerializeField]
    private TMPro.TMP_Text buttonText;
    private void Update() {
        if(Math.DistanceSquare(Player.xCord,transform.position.x,Player.yCord,transform.position.y)<=6){
            buttonText.text=toDisplay;
            actionButton.SetActive(true);
        }
        else actionButton.SetActive(false);
    }       
}