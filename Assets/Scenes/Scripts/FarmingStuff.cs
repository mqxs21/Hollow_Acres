using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingStuff : MonoBehaviour
{
    public HungerController hungerController;
    public AudioSource collectFoodSound;
  //  public GameObject thePitchfork;
   
    // Start is called before the first frame update
    private PlayerDamageController playerDamageController;
    void Start()
    {
        collectFoodSound = GameObject.Find("PlayerCamera").GetComponent<AudioSource>();
        playerDamageController = GameObject.Find("FirstPersonController").GetComponent<PlayerDamageController>();
        if (hungerController == null)
        {
            hungerController = FindAnyObjectByType<HungerController>();
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    void IncreaseHunger(float amount)
    {
        if (hungerController != null)
        {
            hungerController.hungerPercentage += amount;
            hungerController.hungerPercentage = Mathf.Clamp(hungerController.hungerPercentage, 0, hungerController.maxHunger);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Food")
        {
            collectFoodSound.Play();
            Destroy(collision.gameObject);
                IncreaseHunger(10);
                Debug.Log("Collision with Food!");
            
            
        }else if (collision.gameObject.tag == "FoodTom"){
            collectFoodSound.pitch -=0.2f;
            collectFoodSound.Play();
            Destroy(collision.gameObject);
                playerDamageController.curPlayerHealth+=10;
        }
    }
}
