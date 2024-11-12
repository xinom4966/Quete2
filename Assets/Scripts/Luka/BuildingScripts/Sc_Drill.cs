using System.Collections.Generic;
using UnityEngine;

public class Sc_Drill : Sc_Buildings
{
    private Sc_Tile<Sc_InventoryItem> _centerTile;
    private List<Sc_Tile<Sc_InventoryItem>> _neighbours;
    [SerializeField] private Sc_InventoryDisplay _inventoryDisplayScript;
    private Sc_Inventory _drillInventory;
    [SerializeField] private GameObject _inventoryDisplay;
    [SerializeField] private Sc_BuildingPlacementHandler _buildingHandler;

    private void Start()
    {
        _drillInventory = new Sc_Inventory(gameObject, 1, 1);
    }

    private void FixedUpdate()
    {
        if (_buildingHandler.isFixed)
        {
            Extract();
        }
    }

    protected override void Extract()
    {
        _centerTile = gridManager.GetClosestTile(transform.position);
        _neighbours = gridManager.GetNeighbors(_centerTile);
        foreach (Sc_Tile<Sc_InventoryItem> tile in _neighbours)
        {
            if (tile.HasEntity())
            {
                _drillInventory.AddToStorage(tile.GetEntity());
            }
        }
    }

    protected override bool DetectRessources()
    {
        return false;
    }

    protected override void Interact()
    {
        _inventoryDisplayScript.SetInventoryRef(_drillInventory);
        _inventoryDisplay.SetActive(!_inventoryDisplay.activeSelf);
    }

    public void SetUpDrill()
    {
        _drillInventory = new Sc_Inventory(gameObject, inventorySizeX, inventorySizeY);
        //_inventoryDisplayScript = _inventoryDisplay.GetComponentInChildren<Sc_InventoryDisplay>();
    }

    private void OnMouseDown()
    {
        Interact();
    }
}
