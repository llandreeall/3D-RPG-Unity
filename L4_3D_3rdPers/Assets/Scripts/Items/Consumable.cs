using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
	public ConsumableModifier cm;
	public int value;
	public SkinnedMeshRenderer mesh;

	// When pressed in inventory
	public override void Use()
	{
		base.Use();
		PlayerManager.instance.SetHealth(value);
		RemoveFromInventory();                  
	}

}

public enum ConsumableModifier { Health }