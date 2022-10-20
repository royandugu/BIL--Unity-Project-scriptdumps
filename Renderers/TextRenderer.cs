using UnityEngine;
using TMPro;
class TextRenderer:MonoBehaviour{
    [SerializeField]
    private TMP_Text textMesh;
    private void Start() {
        /*
            1. Get all the required information, which NPC is it and it's tree
        */
        byte npcNumber=FindObjectOfType<CurrentNpcHolder>().npcNumber;
        Debug.Log(npcNumber);
    }
}