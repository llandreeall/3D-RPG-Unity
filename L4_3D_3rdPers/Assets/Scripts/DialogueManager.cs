using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;

	public GameObject yesButton;
	public GameObject noButton;
	public GameObject continueButton;

	Quest questInterm;

	void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue, Quest q)
	{
		animator.SetBool("IsOpen", true);
		questInterm = q;
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void StartDialogueNormal(Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			continueButton.SetActive(false);
			if (nameText.text == "Doge") {
				yesButton.SetActive(true);
				noButton.SetActive(true);
			} 
			else
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.005f);
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		questInterm = null;
	}

	public void OnYesButton()
    {
		questInterm.isActive = true;
		GetComponent<Quests>().Add(questInterm);
		
		EndDialogue();
	}

	public void OnNoButton()
    {
		EndDialogue();
	}

}