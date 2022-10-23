using UnityEngine;
using TMPro;
class TextRenderer:MonoBehaviour{
    //Fetching classes
    
    //Textrender instances
    [SerializeField]
    private TMP_Text textMesh;
    private byte npcNo,phaseNo;
    private byte[] convTree;
    private void Start() {
        npcNo=FindObjectOfType<CurrentNpcHolder>().npcNumber;
        //phaseOne
        
    }
}