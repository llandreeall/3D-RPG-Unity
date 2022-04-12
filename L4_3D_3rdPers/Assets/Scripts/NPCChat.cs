using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]
public class NPCChat : Interactable
{
    DialogueTrigger dt;

    void Start()
    {
        dt = GetComponent<DialogueTrigger>();
    }

    public override void Interact()
    {
        base.Interact();

        dt.TriggerDialogue();
    }


}
