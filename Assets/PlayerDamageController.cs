using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    public int curPlayerHealth;
    public int maxPlayerHealth;
    void Start()
    {
        if (maxPlayerHealth == 0)
        {
            Debug.Log("asign max player health por favor");
        }
        curPlayerHealth = maxPlayerHealth;
    }
    void Update()
    {
        
    }
    void Hit(int damage){
        curPlayerHealth-=damage;
    }
    void HandleDeath(){
        if (curPlayerHealth<=0)
        {
            //What to do when die
        }
    }
}
