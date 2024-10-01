using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchforkAttackTriggerController : MonoBehaviour
{
    [SerializeField] Animator pitchforkAnimator;
    [SerializeField] int damage = 10;
    void OnCollisionEnter(Collision hit){
    Debug.Log("Collision detected with: " + hit.gameObject.name);
    if (hit.gameObject.CompareTag("Enemy"))
    {
        Debug.Log("Hitting an enemy: " + hit.gameObject.name);
        hit.gameObject.GetComponent<EnemyAI>().hit(damage);
    }
    else
    {
        Debug.Log("Hit but not an enemy, object: " + hit.gameObject.name);
    }
}

}
