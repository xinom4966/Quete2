using UnityEngine;

public class Sc_Buildings : Sc_InventoryItem
{
    protected string _buildingName;
    protected int _buildingId;
    [HideInInspector] public Sc_GridManager gridManager;
    [HideInInspector] public int inventorySizeX;
    [HideInInspector] public int inventorySizeY;

    protected virtual Sc_Ressource BurnMaterial()
    {
        return null;
    }

    protected virtual void Extract()
    {
        
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

    protected virtual void Interact()
    {

    }
}
