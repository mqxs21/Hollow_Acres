using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantKiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("script running");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.tag == "Hitbox")
        {
            Debug.Log("Touched the plant");
            // Plant killing logic here
        }
    }

}
