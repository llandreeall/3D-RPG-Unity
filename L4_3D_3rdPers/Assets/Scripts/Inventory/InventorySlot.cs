using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

	public Image icon;         
	public Button removeButton;
	public Text text;
	Item item;
	bool assigned = false;

	public void AddItem(Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
		text.enabled = true;
		assigned = true;
	}

	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
		text.enabled = false;
		assigned = false;
	}

	public void OnRemoveButton()
	{
		Inventory.instance.Remove(item);
		assigned = false;
	}

	public void UseItem()
	{
		if (item != null)
		{
			item.Use();
			assigned = false;
			HideTool();
			
		}
	}

	public void HoverTool()
    {
		if (assigned == true)
		{
			string str = "";
			if (item is Equipment)
			{
				Equipment eq = item as Equipment;
				str += item.name + " - attack: " + eq.damageModifier.ToString() + " , armor: " + eq.armorModifier.ToString();

			}
			else if (item is Consumable)
			{
				Consumable cons = item as Consumable;
				str += item.name + " - health: " + cons.value.ToString();
			}
			PlayerManager.instance.tool.ShowTooltip(str);
		}
    }

	public void HideTool()
	{
		PlayerManager.instance.tool.HideTooltip();
	}

}