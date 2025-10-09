using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public static event Action<ClickableObject> OnItemAdded; 

    [Header("Inventaire actuel")]
    public List<ClickableObject> inventory = new List<ClickableObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddToInventory(ClickableObject obj)
    {
        if (!inventory.Contains(obj))
        {
            inventory.Add(obj);
            Debug.Log($"Objet ajouté à l’inventaire : {obj.ObjectName}");

            OnItemAdded?.Invoke(obj);
        }
        else
        {
            Debug.LogWarning($"L’objet {obj.ObjectName} est déjà dans l’inventaire !");
        }
    }
}
