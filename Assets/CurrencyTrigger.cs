using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyTrigger : MonoBehaviour
{
    public CurrencyController currencyController;
    public AudioSource gemCollectSound;
    void Start(){
        gemCollectSound = GameObject.Find("Joint").GetComponent<AudioSource>();
        currencyController = GameObject.Find("FirstPersonController").GetComponent<CurrencyController>();
    }
    void OnCollisionEnter(Collision hit){
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            gemCollectSound.Play();
            currencyController.addCurrency(1);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
