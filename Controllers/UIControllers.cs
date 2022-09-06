using UnityEngine;
using TMPro;
public class UIControllers : MonoBehaviour
{
    [SerializeField]
    private GameObject[] uiComponents;
    [SerializeField]
    private TMP_Text sentence;
    public void MakeInvisible(int index){
        sentence.enabled=false;
        FindObjectOfType<TextRenderer>().RenderSentence(sentence);
        if(uiComponents[index].activeSelf) uiComponents[index].SetActive(false);
        else return;
    }
    public void MakeVisible(int index){
        sentence.enabled=true;
        FindObjectOfType<TextRenderer>().RenderSentence(sentence);
        if(uiComponents[index].activeSelf) return;
        else uiComponents[index].SetActive(true);
    }
}
