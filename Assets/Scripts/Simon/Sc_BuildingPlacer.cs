using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sc_BuildingPlacer : MonoBehaviour
{
    private GameObject _buildingPrefab;
    private GameObject _toBuild;
    private Camera _camera;
    private Vector3 _mousePos;

    private void Awake()
    {
        _buildingPrefab = null;
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_buildingPrefab != null)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                _toBuild.SetActive(false);
            }
            else
            {
                _toBuild.SetActive(true);
            }

            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _toBuild.transform.position = new Vector3(_mousePos.x, _mousePos.y, 0);
            if (Input.GetMouseButtonDown(0))
            {
                Sc_BuildingPlacementHandler handler = _toBuild.GetComponent<Sc_BuildingPlacementHandler>();
                handler.SetPlacementState(PlacementState.Fixed);

                _buildingPrefab = null;
                _toBuild = null;
            }
        }
    }

    public void SetBuildingPrefab(GameObject p_prefab)
    {
        _buildingPrefab = p_prefab;
        PrepareBuilding();
    }

    private void PrepareBuilding()
    {
        if (_toBuild)
        {
            Destroy( _toBuild );
        }
        _toBuild = Instantiate(_buildingPrefab);
        _toBuild.SetActive(false);

        Sc_BuildingPlacementHandler handler = _toBuild.GetComponent<Sc_BuildingPlacementHandler>();
        handler._isFixed = false;
        handler.SetPlacementState(PlacementState.Valid);
    }
}
