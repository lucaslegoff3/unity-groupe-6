using UnityEngine;
using TMPro; // Pour TextMeshPro

public class InputChecker : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField; // R�f�rence � ton champ de texte
    [SerializeField] private string correctAnswer = "bonjour"; // La bonne r�ponse
    [SerializeField] private TextMeshProUGUI feedbackText; // Un texte pour afficher le r�sultat (facultatif)

    public void CheckAnswer()
    {
        // R�cup�re le texte entr� et le nettoie (majuscules, espaces inutiles, etc.)
        string userInput = inputField.text.Trim().ToLower();

        if (userInput == correctAnswer.ToLower())
        {
            feedbackText.text = "? Bonne r�ponse !";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "? Mauvaise r�ponse, essaie encore.";
            feedbackText.color = Color.red;
        }
    }
}
