using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField]
    private float limit;
    private PlayerController playerController;
    
    private void Start() {
        playerController=FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if(Player.yCord+limit>transform.position.y) this.GetComponent<SpriteRenderer>().sortingLayerName="Random";
        else this.GetComponent<SpriteRenderer>().sortingLayerName="Colliders";
    }
}
