using UnityEngine;
public class UIControllers : MonoBehaviour
{
    [SerializeField]
    private GameObject[] uiComponents;
    public void MakeInvisible(int index){
        if(uiComponents[index].activeSelf) uiComponents[index].SetActive(false);
    }
    public void MakeVisible(int index){
        if(uiComponents[index].activeSelf) return;
        else uiComponents[index].SetActive(true);
    }
}
