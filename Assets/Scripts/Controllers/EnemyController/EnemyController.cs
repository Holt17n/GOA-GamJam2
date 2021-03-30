using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    
    public int damageAmount = 10;
    [SerializeField]
    float attackTime = 10f;

    //Update Counter
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        float distance = Vector3.Distance(target.position, transform.position);

        //Slow down attack
        if (counter >= 10)
        {
            counter = 0;

            if (distance <= lookRadius)
            {

                agent.SetDestination(target.position);

                if (distance <= agent.stoppingDistance)
                {
                    //Attack Player
                    //Face Player
                    FaceTarget();
                    AttackPlayer();
                    //Debug.Log("Attack");
                }
            }
        }
    }

    void AttackPlayer()
    {
        StartCoroutine(AttackTime());
    }

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(0f);
        PlayerHealth.singleton.DamagePlayer(damageAmount);
        yield return new WaitForSeconds(attackTime);
    }
}
