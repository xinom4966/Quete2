using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_InventoryDisplay : MonoBehaviour
{
    private Sc_Inventory _inventoryRef;
    [SerializeField] private GameObject _inventoryDisplayTilePrefab;
    private GameObject _inventoryDisplayTile;
    private List<GameObject> _tileList = new List<GameObject>();

    private void OnEnable()
    {
        for (int i = 0; i < _inventoryRef.storageGrid.Count; i++)
        {
            for (int j = 0; j < _inventoryRef.storageGrid[i].Count; j++)
            {
                _inventoryDisplayTile = Instantiate(_inventoryDisplayTilePrefab, this.transform);
                _tileList.Add(_inventoryDisplayTile);
            }
        }
    }

    private void OnDisable()
    {
        foreach (GameObject tile in _tileList)
        {
            if (tile != null)
            {
                Destroy(tile);
            }
        }
        _tileList.Clear();
    }

    public void SetInventoryRef(Sc_Inventory p_inventory)
    {
        _inventoryRef = p_inventory;
    }
}
