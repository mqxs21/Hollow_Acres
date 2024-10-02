using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    public Transform playerTransform;
    public bool enemyCanMove = true;
    public int maxHp = 100;
    public float sightRange;
    public int currHp = 100;
    public LayerMask whatIsPlayer;
    public Animator skeleAnimator;
    public bool playerInSightRange;
    public bool playerInAttackRange;
    public float attackRange = 2;
    public bool stillAlive = true;
    public GameObject getHitEffect;
    void Start()
    {
        stillAlive = true;
        currHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(stillAlive){
             if (playerInSightRange && !playerInAttackRange)
        {
            agent.enabled = true;
            agent.SetDestination(playerTransform.position);
            Debug.Log("in sight range");
            skeleAnimator.SetBool("isWalking",true);
            skeleAnimator.SetBool("isAttacking",false);
            
        }else if (playerInAttackRange)
        {
            Debug.Log("in attack range");
            agent.SetDestination(transform.position);
            skeleAnimator.SetBool("isAttacking",true);
            skeleAnimator.SetBool("isWalking",false);
        }else{
            agent.enabled = false;
            skeleAnimator.SetBool("isAttacking",false);
            skeleAnimator.SetBool("isWalking",false);
        }
        
        }
       
        if (currHp<=0)
        {
            stillAlive = false;
            skeleAnimator.SetBool("isAttacking",false);
            skeleAnimator.SetBool("isWalking",false);
            Die();
        }
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);

    }
    public void hit(int damage){
        currHp-=damage;
        Instantiate(getHitEffect,transform.position,Quaternion.identity);
    }
    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.CompareTag("AttackTrigger") && collision.gameObject.GetComponentInParent<Animator>().GetBool("isStabbing"))
        {
            hit(10);
        }
    }

    void Die() {
        Destroy(this.transform.parent.gameObject);
}

   
}
