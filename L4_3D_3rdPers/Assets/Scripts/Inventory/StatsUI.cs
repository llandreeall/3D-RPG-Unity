using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{

	public Transform itemsParent;   
	public GameObject statsUI;

	public Text attack;
	public Text defense;
	public Text health;
	public Text speed;

	Inventory inventory;

	void Start()
	{
		UpdateUI();

		inventory = Inventory.instance;
		EquipmentManager.instance.onEquipmentChangedSimple += UpdateAttack;
		EquipmentManager.instance.onEquipmentChangedSimple += UpdateDefense;
		

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			statsUI.SetActive(!statsUI.activeSelf);
			UpdateUI();
		}
	}

	void UpdateUI()
	{
		attack.text = PlayerManager.instance.GetDamage().ToString();
		defense.text = PlayerManager.instance.GetArmor().ToString();
		health.text = PlayerManager.instance.GetHealth().ToString();
		
		speed.text = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().speed.ToString();
	}

	public void UpdateHealth()
    {
		health.text = PlayerManager.instance.GetHealth().ToString();
	}

	public void UpdateAttack()
	{
		attack.text = PlayerManager.instance.GetDamage().ToString();
	}

	public void UpdateDefense()
	{
		defense.text = PlayerManager.instance.GetArmor().ToString();
	}


}