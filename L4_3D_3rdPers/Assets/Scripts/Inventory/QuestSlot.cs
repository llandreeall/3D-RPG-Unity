using UnityEngine;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour
{
      
	public Text text;
	public Text goldText;
	Quest quest;

	public void AddItem(Quest q)
	{
		quest = q;
		text.enabled = true;
		text.text = q.description;
		goldText.text = q.goldReward.ToString();
	}

	public void ClearSlot()
	{
		quest = null;
		text.text = "";
		text.enabled = false;
		goldText.text = "";
	}


}