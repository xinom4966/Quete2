using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_InventoryTile : MonoBehaviour
{
    [SerializeField] private Image _image;
    private List<Sc_InventoryItem> _objects;
    private Sc_BuildingGridPlacer _gridPlacer;

    public void TileAction()
    {
        if (_objects.Count > 0)
        {
            _gridPlacer.SetBuildingPrefab(_objects[0].prefab);
            Debug.Log("used object");
        }
        else
        {
            Debug.Log("this slot is empty " + gameObject.name);
        }
    }

    public Sc_InventoryTile()
    {
        _objects = new List<Sc_InventoryItem>();
    }

    public bool IsEmpty()
    {
        return _objects.Count == 0;
    }

    public void AddObject(Sc_InventoryItem p_obj)
    {
        _objects.Add(p_obj);
        Debug.Log("Added " +  p_obj + "to " + gameObject.name);
    }

    public bool RemoveObjects(int p_quantityToRemove)
    {
        if (_objects.Count - p_quantityToRemove > 0)
        {
            return false;
        }
        for (int i = 0; i < p_quantityToRemove; i++)
        {
            _objects.RemoveAt(_objects.Count);
        }
        return true;
    }

    public void UpdateTileVisuals()
    {
        _image.sprite = _objects[0].sprite;
    }

    public void SetGridPlacer(Sc_BuildingGridPlacer p_gridPlacer)
    {
        _gridPlacer = p_gridPlacer;
    }
}
