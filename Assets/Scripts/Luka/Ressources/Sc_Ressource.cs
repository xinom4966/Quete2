using UnityEngine;

public class Sc_Ressource : Sc_InventoryItem
{
    [SerializeField] protected string _ressourceName;
    [SerializeField] protected int _ressourceId;
    [SerializeField] protected int _burningTime;
    [SerializeField] protected bool _canBurn;
    [SerializeField] protected bool _isFuel;
    [SerializeField] protected Sc_Ressource _resultatFour;
}
