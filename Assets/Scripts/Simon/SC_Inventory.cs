using System.Collections.Generic;
using UnityEngine;

public class SC_Inventory<T> : MonoBehaviour where T : class
{
    private List<List<Sc_InventoryTile<T>>> _storageGrid;

    private void CreateStorageGrid(int p_sizeLines, int p_sizeColumns)
    {
        for (int i = 0; i < p_sizeLines; i++)
        {
            _storageGrid.Add(new());
            for (int j = 0; j < p_sizeColumns; j++)
            {
                Sc_InventoryTile<T> inventoryTile = new Sc_InventoryTile<T>();
                _storageGrid[i].Add(inventoryTile);
            }
        }
    }

    private void AddToStorage(T p_objectToAdd)
    {
        for (int i=0; i < _storageGrid.Count; i++)
        {
            for (int j=0; j < _storageGrid[i].Count; j++)
            {
                if (_storageGrid[i][j].IsEmpty())
                {
                    _storageGrid[i][j].AddObject(p_objectToAdd);
                }
            }
        }
    }

    private void RemoveFromStorage(int p_indLine, int p_indColumns, int p_quantityToRemove)
    {
        _storageGrid[p_indLine][p_indColumns].RemoveObjects(p_quantityToRemove);
    }
}
