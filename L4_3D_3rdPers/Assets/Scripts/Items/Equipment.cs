using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
	public EquipmentSlot equipSlot; 

	public int armorModifier;       
	public int damageModifier;
	public WeaponType typeOfWeapon;
	public SkinnedMeshRenderer mesh;
	public EquipmentManager.MeshBlendShape[] coveredMeshRegions;

	// When pressed in inventory
	public override void Use()
	{
		base.Use();
		EquipmentManager.instance.Equip(this);  
		RemoveFromInventory();                  
	}

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
public enum WeaponType { Melee, Ranged }