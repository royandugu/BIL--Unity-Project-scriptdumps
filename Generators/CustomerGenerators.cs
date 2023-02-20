using UnityEngine;
public class CustomerGenerators : MonoBehaviour {
    private void Start() {
        GenerateCustomers();
    }
    public System.Collections.IEnumerator GenerateCustomers(){
        yield return new WaitForSeconds(4);

    }
}