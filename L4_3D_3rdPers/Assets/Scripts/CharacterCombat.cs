using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{

	public float attackSpeed = 1f;
	private float attackCooldown = 0f;
	const float combatCooldown = 5f;
	float lastAttackTime;

	public float attackDelay = .6f;

	public event System.Action OnAttack;

	public CharacterStats myStats;
	public bool inCombat;
	public WeaponType attackType;

	void Start()
	{
		myStats = GetComponent<CharacterStats>();
	}

	void Update()
	{
		attackCooldown -= Time.deltaTime;

		if(Time.time - lastAttackTime > combatCooldown)
        {
			inCombat = false;
        }
	}

	public void Attack(CharacterStats targetStats)
	{
		if (attackCooldown <= 0f)
		{
			StartCoroutine(DoDamage(targetStats, attackDelay));

			if (OnAttack != null)
				OnAttack();

			attackCooldown = 1f / attackSpeed;
			inCombat = true;
			lastAttackTime = Time.time;
		}

	}

	IEnumerator DoDamage(CharacterStats stats, float delay)
	{
		yield return new WaitForSeconds(delay);

		stats.TakeDamage(myStats.damage.GetValue());
		if(stats.currentHealth <= 0)
        {
			inCombat = false;
			if(stats.transform.name == "Enemy1" || stats.transform.name == "Enemy2")
            {
				foreach(Quest q in Quests.instance.quests)
                {
					q.goal.EnemyKilled();
                    if (q.goal.IsReached())
                    {
						PlayerManager.instance.SetGold(q.goldReward);
						Quests.instance.Remove(q);

                    }
                }
				
            }
			
				
		}
	}

}