using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{

	public Image icon;         
	Item item;
	public Text priceText;

    private void Start()
    {
        
    }

    public void AddItem(Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		priceText.text = item.price.ToString();
	}

	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
	}

	public void AddItemToPlayer()
    {
		if (PlayerManager.instance.GetGold() >= item.price)
		{
			Inventory.instance.Add(item);
			PlayerManager.instance.SetGold(-item.price);

		}
	}

	public void HoverTool()
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

	public void HideTool()
    {
		PlayerManager.instance.tool.HideTooltip();
	}
}