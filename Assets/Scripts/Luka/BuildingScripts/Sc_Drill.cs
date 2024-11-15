using System.Collections;
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
    [SerializeField] private float _waitTimeBetweenExtractions;
    [SerializeField] private float _extractionSpeed;
    private bool _isExtracting = false;

    protected override void Start()
    {
        _drillInventory = new Sc_Inventory(gameObject, 1, 1);
    }

    private void FixedUpdate()
    {
        if (_buildingHandler.isFixed)
        {
            TryExtracting();
        }
    }

    private void TryExtracting()
    {
        if (!_isExtracting)
        {
            StartCoroutine(ExtractCoroutine());
        }
    }

    IEnumerator ExtractCoroutine()
    {
        _isExtracting = true;
        _centerTile = gridManager.GetClosestTile(transform.position);
        Debug.Log("drill: " + _centerTile.gridPos + " " + _centerTile.HasEntity());
        _neighbours.Add(_centerTile);
        _neighbours = gridManager.GetNeighbors(_centerTile);
        foreach (Sc_Tile<Sc_InventoryItem> tile in _neighbours)
        {
            Debug.Log("2");
            if (tile.HasEntity())
            {
                _drillInventory.AddToStorage(tile.GetEntity());
                Debug.Log("adding: " + tile.GetEntity() + " to drill");
            }
            yield return new WaitForSeconds(_extractionSpeed);
        }
        yield return new WaitForSeconds(_waitTimeBetweenExtractions);
        Debug.Log("3");
        _isExtracting = false;
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

    private void OnMouseDown()
    {
        Interact();
    }
}
