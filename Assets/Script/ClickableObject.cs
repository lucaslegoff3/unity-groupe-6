using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public int identifiant = 0;     // identifiant unique
    public int cliquer = 0;         // 0 = non cliqu�, 1 = cliqu�

    void Start()
    {
        // La variable est � 0 au d�but
        cliquer = 0;
    }

    void Update()
    {
        // Ici on pourrait faire autre chose si besoin
    }

    void OnMouseDown()
    {
        // Si l'objet n'a pas encore �t� cliqu�
        if (cliquer == 0)
        {
            cliquer = 1;
            Debug.Log("Objet cliqu� pour la premi�re fois ! ID : " + identifiant);
        }
        else
        {
            Debug.Log("D�j� cliqu� � action ignor�e.");
        }
    }
}
