using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour
{
   public AudioSource openShopSound;
   public UpgradeStandController upgradeStandController;
   void OnTriggerEnter(Collider hit){
     if (hit.gameObject.CompareTag("Player"))
     {
      openShopSound.Play();
        upgradeStandController.OpenUpMenu();
     }
   }
}
