using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

	public Dialogue dialogue;
	public string NPCChatType;
	public void TriggerDialogue()
	{
		if(NPCChatType == "QuestGiver")
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue, GetComponent<QuestGiver>().quest);
		else if(NPCChatType != "QuestGiver")
        {
			FindObjectOfType<DialogueManager>().StartDialogueNormal(dialogue);
		}
	}

}