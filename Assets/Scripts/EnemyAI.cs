using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    void Start()
    {
        currHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerInSightRange)
        {
            agent.SetDestination(playerTransform.position);
        }
        if (currHp<=0)
        {
            Die();
        }
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (playerInSightRange)
        {
            agent.enabled = true;
        }else{
            agent.enabled = false;
        }
    }
    public void hit(int damage){
        currHp-=damage;
    }
    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.CompareTag("AttackTrigger") && collision.gameObject.GetComponentInParent<Animator>().GetBool("isStabbing"))
        {
            hit(10);
        }
    }
    void Die(){
        Destroy(this.transform.parent.gameObject);
    }
   
}
