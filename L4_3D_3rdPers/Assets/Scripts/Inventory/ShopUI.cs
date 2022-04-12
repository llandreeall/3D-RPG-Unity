using UnityEngine;

public class ShopUI : MonoBehaviour
{

	public Transform itemsParent;   
	public GameObject inventoryUI;  

	Shop inventory;    

	ShopSlot[] slots;  

	void Start()
	{
		inventory = Shop.instance;
		//inventory.onItemChangedCallback += UpdateUI;    

		slots = itemsParent.GetComponentsInChildren<ShopSlot>();
		UpdateUI();
	}

	/*
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
	}
	*/
	

	void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)  
			{
				slots[i].AddItem(inventory.items[i]);  
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}
}