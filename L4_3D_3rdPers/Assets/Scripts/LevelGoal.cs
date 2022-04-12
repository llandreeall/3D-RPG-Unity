using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    #region Singleton

    public static LevelGoal instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public int goalValue = 7;
    public int currentValue = 0;

    public void IncrementValue()
    {
        currentValue++;
        if(currentValue >= goalValue)
        {
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Win");

    }

    public void GoBack()
    {
        SceneManager.LoadScene("Main");
    }
}
