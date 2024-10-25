using System.Collections.Generic;
using UnityEngine;

public class Sc_InventoryTile<T> : MonoBehaviour
{
    private List<T> objects = new List<T>();

    public bool IsEmpty()
    {
        return objects.Count == 0;
    }

    public void AddObject(T p_obj)
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
}
