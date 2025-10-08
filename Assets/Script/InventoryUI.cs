using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject fenetreInventaire; // Le panel d'inventaire

    private bool inventaireOuvert = false;

    public void ToggleInventaire()
    {
        inventaireOuvert = !inventaireOuvert;
        fenetreInventaire.SetActive(inventaireOuvert);
    }
}