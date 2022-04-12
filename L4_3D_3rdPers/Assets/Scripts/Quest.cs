using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public string title;
    public string description;
    public int goldReward;
    public bool isActive;
    public QuestGoal goal;
}
