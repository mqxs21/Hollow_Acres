using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
  [SerializeField] GameObject pitchfork;
  [SerializeField] Animator pitchformAnimator;
  public AudioSource stabSoundEffect;
  public FirstPersonController firstPersonController;
  public InventoryUIController inventoryUIController;
  void Start(){
    inventoryUIController = FindFirstObjectByType<InventoryUIController>();
    stabSoundEffect = GetComponent<AudioSource>();
  }
  void Update(){
    if (!pitchformAnimator.GetBool("isStabbing") && !pitchformAnimator.GetBool("isHarv") && Input.GetMouseButtonDown(0)&& firstPersonController.enabled && !inventoryUIController.inventoryPanel.activeSelf)
    {
        pitchformAnimator.SetBool("isStabbing",true);
        stabSoundEffect.Play();
        StartCoroutine(DelaySetToFalse("isStabbing"));
    }

  }
  IEnumerator DelaySetToFalse(string set){
    yield return new WaitForSeconds(0.2f);
    pitchformAnimator.SetBool(set,false);
  }
}
