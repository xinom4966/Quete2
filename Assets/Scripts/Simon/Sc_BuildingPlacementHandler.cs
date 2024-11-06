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
    private Color _fixedColor;
    public bool hasValidPlacement;
    public bool isFixed;
    private int _obstacleNumber;

    private void Awake()
    {
        hasValidPlacement = true;
        isFixed = true;
        _obstacleNumber = 0;
        _fixedColor = _spriteRenderer.color;
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
                _spriteRenderer.color = _fixedColor;
                break;
            case PlacementState.Valid:
                _spriteRenderer.color = _validColor;
                break;
            case PlacementState.Invalid:
                _spriteRenderer.color = _invalidColor;
                break;
            default:
                _spriteRenderer.color = _fixedColor;
                break;
        }
    }

    public void SetBuildingGridManager(Sc_GridManager p_gridManager)
    {
        _building.gridManager = p_gridManager;
    }
}
