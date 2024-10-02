using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordTrigger : MonoBehaviour
{
    public Animator skeletonAnimator;
    public int attackDamage = 20;
    void OnTriggerEnter(Collider hit){
        if (hit.gameObject.CompareTag("Player") && skeletonAnimator.GetBool("isAttacking"))
        {
            hit.gameObject.GetComponent<PlayerDamageController>().Hit(attackDamage);
            Debug.Log("hit");
        }
    }
}
