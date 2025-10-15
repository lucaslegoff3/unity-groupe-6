using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextValidatorManager : MonoBehaviour
{
    [Header("Panel echec")]
    public GameObject panelEchec;

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
        Debug.Log("Ouverture du panel menu");
        if (panelEchec != null)
            panelEchec.SetActive(true);
    }

    public void GoodSoluce()
    {
        Debug.Log("GOOD SOLUCE");
        SceneManager.LoadScene("VideoVictoire");
    }
}
