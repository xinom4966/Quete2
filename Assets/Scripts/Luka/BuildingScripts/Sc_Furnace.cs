using System.Data.SqlTypes;
using UnityEngine;

public class Sc_Furnace : MonoBehaviour
{
    [HideInInspector] public Sc_InventoryTile fuelSlot;
    [HideInInspector] public Sc_InventoryTile smeltingSlot;
    [HideInInspector] public Sc_InventoryTile outcomeSlot;

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
