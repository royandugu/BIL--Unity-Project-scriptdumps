using UnityEngine;
using TMPro;
class TextRenderer:MonoBehaviour{
    //Read from the file and all
    public void RenderSentence(TMP_Text sentence){
        sentence.text="Hello I am a circle";
    }
}