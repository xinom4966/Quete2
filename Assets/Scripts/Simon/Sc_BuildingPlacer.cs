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
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(_toBuild);
                _toBuild = null;
                _buildingPrefab = null;
                return;
            }

            if (EventSystem.current.IsPointerOverGameObject())
            {
                _toBuild.SetActive(false);
            }
            else
            {
                _toBuild.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _toBuild.transform.Rotate(Vector3.forward, 90);
            }

            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _toBuild.transform.position = new Vector3(_mousePos.x, _mousePos.y, 0);
            if (Input.GetMouseButtonDown(0))
            {
                Sc_BuildingPlacementHandler handler = _toBuild.GetComponent<Sc_BuildingPlacementHandler>();
                if (handler.hasValidPlacement)
                {
                    handler.SetPlacementState(PlacementState.Fixed);

                    _buildingPrefab = null;
                    _toBuild = null;
                }
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
        handler.isFixed = false;
        handler.SetPlacementState(PlacementState.Valid);
    }
}
