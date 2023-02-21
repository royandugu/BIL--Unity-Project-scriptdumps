using UnityEngine;
public class CustomerGenerators : MonoBehaviour {
    [SerializeField]
    private GameObject customerSample,toBeServed;
    private bool initial=true;
    private int listCount=0,firstEntry=0; 
    //Unity built-ins
    private void Start() {
        customerSample.SetActive(false);
        StartCoroutine(GenerateCustomers());
    }
    //User defined
    public System.Collections.IEnumerator GenerateCustomers(){
        float interval=Math.IntervalCalculator();
        yield return new WaitForSeconds(interval);
        if(initial) {
            customerSample.SetActive(true);
            initial=false;
        }
        else{
            Object.Instantiate<GameObject>(customerSample);
        }
        StartCoroutine(GenerateCustomers());
    }
}