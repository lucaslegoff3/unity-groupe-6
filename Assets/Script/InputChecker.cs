using TMPro;
using UnityEngine;

public class InputValidator : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private string correctAnswer;

    public bool CheckIfCorrect()
    {
        if (correctAnswer == inputField.text) 
        {
            Debug.Log("Good " + correctAnswer);
            return true;
        }
        else
        {
            Debug.Log("False " + correctAnswer);
            return false;
        }
    }
}
