using System.Data.SqlTypes;
using UnityEngine;


public class Sc_Furnace : Sc_Buildings
{
    [HideInInspector] public Sc_InventoryTile fuelSlot;
    [HideInInspector] public Sc_InventoryTile smeltingSlot;
    [HideInInspector] public Sc_InventoryTile outcomeSlot;

    public bool isOn;

    protected override void Start()
    {

    }

    protected override void Update()
    {
        if (fuelSlot != null)
        {

        }
    }
}
