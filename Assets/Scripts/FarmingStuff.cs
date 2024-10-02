using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingStuff : MonoBehaviour
{
    public HungerController hungerController;
  //  public GameObject thePitchfork;
   
    // Start is called before the first frame update
    void Start()
    {
        if (hungerController == null)
        {
            hungerController = FindObjectOfType<HungerController>();
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
            Destroy(collision.gameObject);
            IncreaseHunger(10f);
            Debug.Log("Collision with Food!");
        }
    }
}
