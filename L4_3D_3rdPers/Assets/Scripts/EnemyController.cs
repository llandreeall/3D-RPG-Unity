using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	public float lookRadius = 10f;  

	Transform target;   
	NavMeshAgent agent; 
	CharacterCombat combat;

	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;


	public float sightRange, attackRange;
	public bool playerInSightRange, playerInAttackRange;
	public LayerMask whatIsPlayer;
	public LayerMask whatIsGround;

	void Start()
	{
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		combat = GetComponent<CharacterCombat>();
	}

	void Update()
	{
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

		if (!playerInSightRange)
		{
			Patroling();
		}
		else
		{
			float distance = Vector3.Distance(target.position, transform.position);

			if (distance <= lookRadius)
			{
				agent.SetDestination(target.position);

				if (distance <= attackRange)
				{
					CharacterStats targetStats = target.GetComponent<CharacterStats>();
					if (targetStats != null)
					{
						combat.Attack(targetStats);
					}

					FaceTarget();
				}
			}
		}
	}

	void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

	private void Patroling()
    {
		if (!walkPointSet) SearchWalkPoint();
		else
        {
			agent.SetDestination(walkPoint);
        }

		Vector3 distanceToWalkPoint = transform.position - walkPoint;
		//Debug.Log(distanceToWalkPoint.magnitude);
		if (distanceToWalkPoint.magnitude < 3f)
			walkPointSet = false;

    }

	private void SearchWalkPoint()
    {
		float randomZ = Random.Range(-walkPointRange, walkPointRange);
		float randomX = Random.Range(-walkPointRange, walkPointRange);

		walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

		if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
			walkPointSet = true;
        }
	}
}