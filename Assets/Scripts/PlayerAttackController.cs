using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
  [SerializeField] GameObject pitchfork;
  [SerializeField] Animator pitchformAnimator;
  void Start(){

  }
  void Update(){
    if (!pitchformAnimator.GetBool("isStabbing") && !pitchformAnimator.GetBool("isHarv") && Input.GetMouseButtonDown(0))
    {
        pitchformAnimator.SetBool("isStabbing",true);
        StartCoroutine(DelaySetToFalse("isStabbing"));
    }
    if (!pitchformAnimator.GetBool("isStabbing") && !pitchformAnimator.GetBool("isHarv") && Input.GetMouseButtonDown(1))
    {
        pitchformAnimator.SetBool("isHarv",true);
        StartCoroutine(DelaySetToFalse("isHarv"));
    }
  }
  IEnumerator DelaySetToFalse(string set){
    yield return new WaitForSeconds(0.3f);
    pitchformAnimator.SetBool(set,false);
  }
}
