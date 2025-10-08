using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public int identifiant = 0;     // identifiant unique
    public int cliquer = 0;         // 0 = non cliqué, 1 = cliqué

    void Start()
    {
        // La variable est à 0 au début
        cliquer = 0;
    }

    void Update()
    {
        // Ici on pourrait faire autre chose si besoin
    }

    void OnMouseDown()
    {
        // Si l'objet n'a pas encore été cliqué
        if (cliquer == 0)
        {
            cliquer = 1;
            Debug.Log("Objet cliqué pour la première fois ! ID : " + identifiant);
        }
        else
        {
            Debug.Log("Déjà cliqué — action ignorée.");
        }
    }
}
