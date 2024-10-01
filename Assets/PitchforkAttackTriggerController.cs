using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchforkAttackTriggerController : MonoBehaviour
{
    [SerializeField] Animator pitchforkAnimator;
    [SerializeField] int damage = 10;
    void OnTriggerEnter(Collider hit){
        if (hit.gameObject.CompareTag("Enemy") && pitchforkAnimator.GetBool("isStabbing"))
        {
            hit.gameObject.GetComponent<EnemyAI>().hit(damage);
            Debug.Log("hit" + hit.gameObject.name);
        }
    }
}
