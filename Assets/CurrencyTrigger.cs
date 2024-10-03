using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyTrigger : MonoBehaviour
{
    public CurrencyController currencyController;
    void Start(){
        currencyController = GameObject.Find("FirstPersonController").GetComponent<CurrencyController>();
    }
    void OnCollisionEnter(Collision hit){
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            currencyController.addCurrency(1);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
