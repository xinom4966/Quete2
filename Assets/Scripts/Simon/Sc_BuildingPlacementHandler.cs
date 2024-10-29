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
    [SerializeField] private Material _validPlacementMaterial;
    [SerializeField] private Material _invalidPlacementMaterial;
    [SerializeField] private MeshRenderer[] _meshComponents;
    private Dictionary<MeshRenderer, List<Material>> _initialMaterials;
    public bool hasValidPlacement;
    public bool isFixed;
    private int _obstacleNumber;

    private void Awake()
    {
        hasValidPlacement = true;
        isFixed = true;
        _obstacleNumber = 0;
        InitializeMaterial();
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

#if UNITY_EDITOR
    private void OnValidate()
    {
        InitializeMaterial();
    }
#endif

    private void InitializeMaterial()
    {
        if (_initialMaterials == null)
            _initialMaterials = new Dictionary<MeshRenderer, List<Material>>();
        if (_initialMaterials.Count > 0)
        {
            foreach (var l in _initialMaterials) l.Value.Clear();
            _initialMaterials.Clear();
        }

        foreach (MeshRenderer r in _meshComponents)
        {
            _initialMaterials[r] = new List<Material>(r.sharedMaterials);
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
        SetMaterial(p_state);
    }

    private void SetMaterial(PlacementState p_state)
    {
        if (p_state == PlacementState.Fixed)
        {
            foreach (MeshRenderer r in _meshComponents)
                r.sharedMaterials = _initialMaterials[r].ToArray();
        }
        else
        {
            Material matToApply = p_state == PlacementState.Valid
                ? _validPlacementMaterial : _invalidPlacementMaterial;

            Material[] m; int nMaterials;
            foreach (MeshRenderer r in _meshComponents)
            {
                nMaterials = _initialMaterials[r].Count;
                m = new Material[nMaterials];
                for (int i = 0; i < nMaterials; i++)
                    m[i] = matToApply;
                r.sharedMaterials = m;
            }
        }
    }
}