using System.Collections.Generic;
using UnityEngine;

public class Sc_ConveyorBelt : MonoBehaviour
{
    [System.Serializable]

    public class ConveyorBeltItem
    {
        public Transform item;
        [HideInInspector] public float currentLerp;
        [HideInInspector] public int startPoint;
    }

    [SerializeField] private float _itemSpacing;
    [SerializeField] private float _speed = 2;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private List<ConveyorBeltItem> _listItems;


    private void FixedUpdate()
    {
        for (int i = 0; i < _listItems.Count; i++)
        {
            ConveyorBeltItem beltItem = _listItems[i];
            Transform item = _listItems[i].item;

            if (i > 0)
            {
                if (Vector3.Distance(item.position, _listItems[i - 1].item.position) <= _itemSpacing)
                {
                    continue;
                }
            }

            item.transform.position = Vector3.Lerp(_lineRenderer.GetPosition(beltItem.startPoint), _lineRenderer.GetPosition(beltItem.startPoint + 1), beltItem.currentLerp);
            float distance = Vector3.Distance(_lineRenderer.GetPosition(beltItem.startPoint), _lineRenderer.GetPosition(beltItem.startPoint + 1));
            beltItem.currentLerp += (_speed * Time.deltaTime) / distance;

            if (beltItem.currentLerp >= 1)
            {
                if (beltItem.startPoint + 2 < _lineRenderer.positionCount)
                {
                    beltItem.currentLerp = 0;
                    beltItem.startPoint++;
                }
            }
        }
    }
}
