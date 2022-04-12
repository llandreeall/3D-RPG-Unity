using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

	#region Singleton

	public static PlayerManager instance;

	void Awake()
	{
		instance = this;
	}

	#endregion

	public GameObject player;
	public Text goldDisplay;
	public StatsUI healthUI;
	public Tooltip tool;

    private void Start()
    {
		SetGoldText();
    }

    public void KillPlayer()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void SetGoldText()
    {
		if (player.GetComponent<PlayerStats>())
		{
			goldDisplay.text = player.GetComponent<PlayerStats>().GetMoney().ToString();

		}
	}

	public void SetGold(int gold)
	{
		if (player.GetComponent<PlayerStats>())
		{
			player.GetComponent<PlayerStats>().GiveMoney(gold);
			SetGoldText();
		}
	}

	public int GetGold()
	{
		if (player.GetComponent<PlayerStats>())
		{
			return player.GetComponent<PlayerStats>().GetMoney();

		}
		else
			return 0;
	}

	public void SetHealth(int health)
	{
		if (player.GetComponent<PlayerStats>())
		{
			player.GetComponent<PlayerStats>().GiveHealth(health);
			healthUI.UpdateHealth();

		}
	}

	public int GetHealth()
	{
		if (player.GetComponent<PlayerStats>())
		{
			return player.GetComponent<PlayerStats>().currentHealth;

		}
		else
			return 0;
	}

	public int GetDamage()
	{
		if (player.GetComponent<PlayerStats>())
		{
			return player.GetComponent<PlayerStats>().damage.GetValue();

		}
		else
			return 0;
	}

	public int GetArmor()
	{
		if (player.GetComponent<PlayerStats>())
		{
			return player.GetComponent<PlayerStats>().armor.GetValue();

		}
		else
			return 0;
	}

}