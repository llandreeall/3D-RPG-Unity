using UnityEngine;

public class QuestsUI : MonoBehaviour
{

	public Transform itemsParent;   
	public GameObject questsUI;  

	Quests questsList;    

	QuestSlot[] slots;  

	void Start()
	{
		questsList = Quests.instance;
		questsList.onQuestsChangedCallback += UpdateQuests;    

		slots = itemsParent.GetComponentsInChildren<QuestSlot>();
	}

	void Update()
	{
		if (Input.GetButtonDown("Quests"))
		{
			questsUI.SetActive(!questsUI.activeSelf);
		}
	}

	void UpdateQuests()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < questsList.quests.Count)  
			{
				slots[i].AddItem(questsList.quests[i]);  
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}
}