using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextValidatorManager : MonoBehaviour
{
    public List<InputValidator> inputValidatorList = new();
    public void CheckSoluce()
    {
        for (int i = 0; i < inputValidatorList.Count; i++)
        {
            if (inputValidatorList[i].CheckIfCorrect() == false)
            {
                WrongSoluce();
                return;
            }
        }
        GoodSoluce();
    }

    public void WrongSoluce()
    {
        Debug.Log("WRONG SOLUCE");
    }

    public void GoodSoluce()
    {
        Debug.Log("GOOD SOLUCE");
        SceneManager.LoadScene("VideoVictoire");
    }
}
