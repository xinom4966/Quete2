using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_InventoryTile : MonoBehaviour
{
    [SerializeField] private Image _image;
    public List<Sc_InventoryItem> objects;
    private Sc_BuildingGridPlacer _gridPlacer;

    public void TileAction()
    {
        if (objects.Count > 0)
        {
            _gridPlacer.SetBuildingPrefab(objects[0].prefab);
            Debug.Log("used object");
        }
        else
        {
            Debug.Log("this slot is empty " + gameObject.name);
        }
    }

    public Sc_InventoryTile()
    {
        objects = new List<Sc_InventoryItem>();
    }

    public bool IsEmpty()
    {
        return objects.Count == 0;
    }

    public void AddObject(Sc_InventoryItem p_obj)
    {
        objects.Add(p_obj);
    }

    public bool RemoveObjects(int p_quantityToRemove)
    {
        if (objects.Count - p_quantityToRemove > 0)
        {
            return false;
        }
        for (int i = 0; i < p_quantityToRemove; i++)
        {
            objects.RemoveAt(objects.Count);
        }
        return true;
    }

    public void UpdateTileVisuals()
    {
        _image.sprite = objects[0].sprite;
    }

    public void SetGridPlacer(Sc_BuildingGridPlacer p_gridPlacer)
    {
        _gridPlacer = p_gridPlacer;
    }
}
