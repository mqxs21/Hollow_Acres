using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    public Transform playerTransform;
    public bool enemyCanMove = true;
    public int maxHp = 100;
    public GameObject dropLoot;
    public float sightRange;
    public int currHp = 100;
    public LayerMask whatIsPlayer;
    public Animator skeleAnimator;
    public bool playerInSightRange;
    public bool playerInAttackRange;
    public float attackRange = 2;
    public bool stillAlive = true;
    public GameObject getHitEffect;
    public float rotationSpeed = 5f; 
    public BoxCollider boxCollider;
    public UpgradeStandController upgradeStandController;
    public bool CanTakeDamage = true;

    void Start()
    {
        upgradeStandController = GameObject.Find("UpgradeStand").GetComponent<UpgradeStandController>();
        stillAlive = true;
        currHp = maxHp;
        playerTransform = GameObject.Find("FirstPersonController").transform;
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (stillAlive && upgradeStandController.enemyCanGo)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (playerInSightRange && !playerInAttackRange)
            {
                agent.enabled = true;
                agent.SetDestination(playerTransform.position);
                skeleAnimator.SetBool("isWalking", true);
                skeleAnimator.SetBool("isAttacking", false);
            }
            else if (playerInAttackRange)
            {
                agent.SetDestination(transform.position);
                LookAtPlayerOnYAxis();
                skeleAnimator.SetBool("isAttacking", true);
                skeleAnimator.SetBool("isWalking", false);
         
            }
            else
            {
                agent.enabled = false;
                skeleAnimator.SetBool("isAttacking", false);
                skeleAnimator.SetBool("isWalking", false);
            }
        }

        if (currHp <= 0)
        {
            stillAlive = false;
            skeleAnimator.SetBool("isAttacking", false);
            skeleAnimator.SetBool("isWalking", false);
            Debug.Log("die");
            Die();
        }
    }

      private void LookAtPlayerOnYAxis()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        direction.y = 0; // Keep only the horizontal direction
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    public void hit(int damage)
    {
        currHp -= damage;
        Instantiate(getHitEffect, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("AttackTrigger") && collision.gameObject.GetComponentInParent<Animator>().GetBool("isStabbing") && CanTakeDamage)
        {
            hit(upgradeStandController.weaponAttackDamage);
            CanTakeDamage = false;
            StartCoroutine(damageDelay());
        }
    }

    void Die() 
    {
        Instantiate(dropLoot,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
    IEnumerator damageDelay(){
        yield return new WaitForSeconds(0.2f);
        CanTakeDamage = true;
    }
}
