using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageController : MonoBehaviour
{
    public int curPlayerHealth;
    public Animator getHitAnimatorScreenFlash;
    public int maxPlayerHealth;
    public GameObject transOut;
    public AudioSource getHitAudio;
    public AudioSource walkingAudio;
    public AudioSource runningAudio;
    public UpgradeStandController upgradeStandController;
    
    public FirstPersonController firstPersonController;
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
        if (firstPersonController.enabled && !firstPersonController.isWalking)
        {
            walkingAudio.Play();
            Debug.Log("play walking sound");
        }
        if (firstPersonController.enabled && !firstPersonController.isSprinting )
        {
            runningAudio.Play();
            Debug.Log("playing running sound");
        }
        if (upgradeStandController.menuOpened)
        {
            walkingAudio.Stop();
            runningAudio.Stop();
        }
        HandleDeath();
    }
    public void Hit(int damage){
        getHitAudio.Play();
        curPlayerHealth-=damage;
        getHitAnimatorScreenFlash.SetBool("isHit",true);
        StartCoroutine(screenFlashDelay());
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
    IEnumerator screenFlashDelay(){
        yield return new WaitForSeconds(0.1f);
        getHitAnimatorScreenFlash.SetBool("isHit",false);
    }
}
