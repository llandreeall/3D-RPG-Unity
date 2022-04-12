using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
	#region Singleton

	public static Quests instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Quests found!");
			return;
		}

		instance = this;
	}

	#endregion

	public delegate void OnQuestsChanged();
	public OnQuestsChanged onQuestsChangedCallback;

	public int space = 3;  
	public List<Quest> quests = new List<Quest>();

	public bool Add(Quest q)
	{
		
			if (quests.Count >= space)
			{
				Debug.Log("Not enough room.");
				return false;
			}

			quests.Add(q);    

			if (onQuestsChangedCallback != null)
				onQuestsChangedCallback.Invoke();
		

		return true;
	}

	public void Remove(Quest q)
	{
		quests.Remove(q);    

		if (onQuestsChangedCallback != null)
			onQuestsChangedCallback.Invoke();
	}

}