using System.Collections.Generic;
using UnityEngine;

public class Sc_Inventory
{
    public List<List<Sc_InventoryTile>> storageGrid = new List<List<Sc_InventoryTile>>();

    public Sc_Inventory(int p_sizeX, int p_sizeY)
    {
        CreateStorageGrid(p_sizeX, p_sizeY);
    }

    private void CreateStorageGrid(int p_sizeLines, int p_sizeColumns)
    {
        for (int i = 0; i < p_sizeLines; i++)
        {
            storageGrid.Add(new List<Sc_InventoryTile>());
            for (int j = 0; j < p_sizeColumns; j++)
            {
                Sc_InventoryTile inventoryTile = new Sc_InventoryTile();
                storageGrid[i].Add(inventoryTile);
                storageGrid[i][j] = inventoryTile;
            }
        }
    }

    private void AddToStorage(Sc_InventoryItem p_objectToAdd)
    {
        for (int i=0; i < storageGrid.Count; i++)
        {
            for (int j=0; j < storageGrid[i].Count; j++)
            {
                if (storageGrid[i][j].IsEmpty())
                {
                    storageGrid[i][j].AddObject(p_objectToAdd);
                }
            }
        }
    }

    private void RemoveFromStorage(int p_indLine, int p_indColumns, int p_quantityToRemove)
    {
        storageGrid[p_indLine][p_indColumns].RemoveObjects(p_quantityToRemove);
    }
}
