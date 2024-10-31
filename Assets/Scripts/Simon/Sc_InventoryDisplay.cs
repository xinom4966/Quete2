using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_InventoryDisplay : MonoBehaviour
{
    private Sc_Inventory _inventoryRef;
    [SerializeField] private GameObject _inventoryDisplayTilePrefab;
    private GameObject _inventoryDisplayTile;

    private void OnEnable()
    {
        for (int i = 0; i < _inventoryRef.storageGrid.Count; i++)
        {
            for (int j = 0; j < _inventoryRef.storageGrid[i].Count; j++)
            {
                _inventoryDisplayTile = Instantiate(_inventoryDisplayTilePrefab);
            }
        }
    }

    public void SetInventoryRef(Sc_Inventory p_inventory)
    {
        _inventoryRef = p_inventory;
    }
}
