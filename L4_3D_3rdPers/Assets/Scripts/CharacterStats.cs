using System.Collections;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth { get; private set; }

	public Stat damage;
	public Stat armor;
	public int gold;

	public event System.Action<int, int> OnHealthChanged;


	void Awake()
	{
		currentHealth = maxHealth;
	}

	public void GiveHealth(int val)
    {
		currentHealth += val;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		if (OnHealthChanged != null)
		{
			OnHealthChanged(maxHealth, currentHealth);
		}
	}

	public void TakeDamage(int damage)
	{
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);

		currentHealth -= damage;
		//Debug.Log(transform.name + " takes damage" + damage);
		if(OnHealthChanged != null)
        {
			OnHealthChanged(maxHealth, currentHealth);
        }

		if(transform.tag == "Player")
        {
			PlayerManager.instance.healthUI.UpdateHealth();
        }

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public virtual void Die()
	{
		//Debug.Log(transform.name + " ded");
		//if (transform.name == "Enemy")
		//Destroy(gameObject);
		StartCoroutine(DieAnim());
	}

	private IEnumerator DieAnim()
    {
		Animator anim = gameObject.GetComponentInChildren<Animator>();
		anim.SetBool("isDead", true);
		yield return new WaitForSeconds(1.7f);
		if (transform.name == "Enemy1" || transform.name == "Enemy2")
		{
			LevelGoal.instance.IncrementValue();
			Debug.Log(transform.name + " ded");
			Destroy(gameObject);
		}
	}

	public void GiveMoney(int value)
    {
		gold += value;
    }

	public int GetMoney()
    {
		return gold;
    }

}