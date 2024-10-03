using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageController : MonoBehaviour
{
    public int curPlayerHealth;
    public int maxPlayerHealth;
    public GameObject transOut;
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
        HandleDeath();
    }
    public void Hit(int damage){
        curPlayerHealth-=damage;
    }
    void HandleDeath(){
        if (curPlayerHealth<=0)
        {
            StartCoroutine(deathDelay());
        }
    }
    IEnumerator deathDelay(){
        transOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene(1);
    }
}
