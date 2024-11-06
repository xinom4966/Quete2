using UnityEngine;

public class Sc_Buildings : Sc_InventoryItem
{
    protected string _buildingName;
    protected int _buildingId;
    public Sc_GridManager gridManager;

    protected virtual Sc_Ressource BurnMaterial()
    {
        return null;
    }

    protected virtual Sc_Ressource Extract()
    {
        return null;
    }

    protected virtual bool DetectRessources()
    {
        return false;
    }

    protected virtual void MoveRessources()
    {
        return;
    }

    protected virtual bool DetectBuilding()
    {
        return false;
    }
}
