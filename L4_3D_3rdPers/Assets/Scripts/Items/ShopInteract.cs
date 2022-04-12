using UnityEngine;

public class ShopInteract : NPCChat
{

	public GameObject inventoryUI;

	public override void Interact()
	{
		base.Interact();

		Open();
	}

	void Open()
    {
		inventoryUI.SetActive(!inventoryUI.activeSelf);
		Debug.Log("open");
	}
		
}