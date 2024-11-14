using System.Data.SqlTypes;
using UnityEngine;

public class Sc_Furnace<T> : MonoBehaviour
{
    [HideInInspector] public Sc_InventoryTile<T> fuelSlot;
    [HideInInspector] public Sc_InventoryTile<T> smeltingSlot;
    [HideInInspector] public Sc_InventoryTile<T> outcomeSlot;

    public bool isOn;

    private void Start()
    {

    }

    private void Update()
    {
        if (fuelSlot != null)
        {

        }
    }
}
