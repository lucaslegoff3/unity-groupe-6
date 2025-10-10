using UnityEngine;
using TMPro; // Pour TextMeshPro

public class InputChecker : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField; // Référence à ton champ de texte
    [SerializeField] private string correctAnswer = "bonjour"; // La bonne réponse
    [SerializeField] private TextMeshProUGUI feedbackText; // Un texte pour afficher le résultat (facultatif)

    public void CheckAnswer()
    {
        // Récupère le texte entré et le nettoie (majuscules, espaces inutiles, etc.)
        string userInput = inputField.text.Trim().ToLower();

        if (userInput == correctAnswer.ToLower())
        {
            feedbackText.text = "? Bonne réponse !";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "? Mauvaise réponse, essaie encore.";
            feedbackText.color = Color.red;
        }
    }
}
