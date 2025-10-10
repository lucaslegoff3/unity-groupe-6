using TMPro;
using UnityEngine;

public class InputValidator : MonoBehaviour
{
    // Tableau pour stocker automatiquement tous les InputField ou TMP_InputField
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private string correctAnswer;

    // cette fonction va nous retourner un booleen selon si la réponse est correcte ou non 
    // donc là ça nous retourne false or true selon si la réponse est la même que "correctAnswer"
    // la valeur de correctAnswer va être précisée dans l'inspecteur
    // maintenant il faut juste qu'on appelle cette fonctions
    // on va faire un "manager" qui va appeler cette fonction
    // ce manager ça va être un autre script
    public bool CheckIfCorrect()
    {
        if (correctAnswer == inputField.text) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
