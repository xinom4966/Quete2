using UnityEngine;
using UnityEngine.EventSystems;

public class Sc_BuildingGridPlacer : Sc_BuildingPlacer
{
    [SerializeField] private Sc_GridManager _gridManager;

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
            _toBuild.transform.position = _gridManager.GetClosestTile(_mousePos).pos;
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
}
