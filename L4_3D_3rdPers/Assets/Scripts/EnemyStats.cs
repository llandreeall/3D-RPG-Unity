using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{

	public override void Die()
	{
		base.Die();
		//Debug.Log("just die");
		Destroy(this.gameObject);
	}

}