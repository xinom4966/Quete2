using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum PlacementState
{
    Fixed,
    Valid,
    Invalid
}

public class Sc_BuildingPlacementHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _validColor;
    [SerializeField] private Color _invalidColor;
    [SerializeField] private Sc_Buildings _building;
    [SerializeField] private int _buildingInventorySizeX;
    [SerializeField] private int _buildingInventorySizeY;
    private Color _fixedColor;
    public bool hasValidPlacement;
    public bool isFixed;
    private int _obstacleNumber;
    private Sc_BuildingGridPlacer _buildingPlacer;

    private void Awake()
    {
        hasValidPlacement = true;
        isFixed = true;
        _obstacleNumber = 0;
        if (_spriteRenderer != null)
        {
            _fixedColor = _spriteRenderer.color;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFixed) { return; }
        _obstacleNumber++;
        SetPlacementState(PlacementState.Invalid);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isFixed) { return; }
        _obstacleNumber--;
        if (_obstacleNumber <= 0)
        {
            SetPlacementState(PlacementState.Valid);
        }
    }

    public void SetPlacementState(PlacementState p_state)
    {
        if (p_state == PlacementState.Fixed)
        {
            isFixed = true;
            hasValidPlacement = true;
            _building.inventorySizeX = _buildingInventorySizeX;
            _building.inventorySizeY = _buildingInventorySizeY;
        }
        else if (p_state == PlacementState.Valid)
        {
            hasValidPlacement = true;
        }
        else
        {
            hasValidPlacement = false;
        }
        SetColor(p_state);
    }

    private void SetColor(PlacementState p_state)
    {
        switch (p_state)
        {
            case PlacementState.Fixed:
                if (_spriteRenderer != null)
                    _spriteRenderer.color = _fixedColor;
                break;
            case PlacementState.Valid:
                if (_spriteRenderer != null)
                    _spriteRenderer.color = _validColor;
                break;
            case PlacementState.Invalid:
                if (_spriteRenderer != null)
                    _spriteRenderer.color = _invalidColor;
                break;
            default:
                if (_spriteRenderer != null)
                    _spriteRenderer.color = _fixedColor;
                break;
        }
    }

    public void SetBuildingGridManager(Sc_GridManager p_gridManager)
    {
        _building.gridManager = p_gridManager;
    }

    public void SetBuildingPlacer(Sc_BuildingGridPlacer p_buildingGridPlacer)
    {
        _buildingPlacer = p_buildingGridPlacer;
    }

    public Sc_BuildingGridPlacer GetBuildingPlacer()
    {
        return _buildingPlacer;
    }
}
