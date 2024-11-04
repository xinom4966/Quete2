using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Sc_WalkerGenerator : MonoBehaviour
{
    private enum Grid
    {
        COAL,
        IRON,
        EMPTY
    }

    private Grid[,] _gridHandler;
    private List<Sc_Walker> _walkers;
    private Sc_GridManager _gridManager;

    private int _walkerWidth = 10;
    private int _walkerHeight = 10;
    private int _maxWalker = 5;
    private int _tileCount = default;

    private float _fillPercentage = 0.5f;
    private float _waitTime = 0.05f;

    [SerializeField] private Tilemap _tileMap;
    [SerializeField] private Tile _coal;
    [SerializeField] private Tile _iron;

    private void Start()
    {
        InitializeGrid();
    }

    void InitializeGrid()
    {
        _gridHandler = new Grid[_walkerWidth, _walkerHeight];
        _walkers = new List<Sc_Walker>();

        for (int x = 0; x < _gridHandler.GetLength(0); x++)
        {
            for (int y = 0; y < _gridHandler.GetLength(1); y++)
            {
                _gridHandler[x, y] = Grid.EMPTY;
            }
        }

        //Vector3Int TileCenter = new Vector3Int((int)_gridManager.GetTileCenter().x, (int)_gridManager.GetTileCenter().y, 0);

        Vector3Int WalkerGridCenter = new Vector3Int(_gridHandler.GetLength(0) / 2, _gridHandler.GetLength(1) / 2, 0);

        Sc_Walker currentWalker = new Sc_Walker(new Vector2(WalkerGridCenter.x, WalkerGridCenter.y), GetWalkerDirection(), 0.5f);
        _gridHandler[WalkerGridCenter.x, WalkerGridCenter.y] = Grid.COAL;
        _tileMap.SetTile(WalkerGridCenter, _coal);
        _walkers.Add(currentWalker);

        _tileCount++;

        StartCoroutine(CreateFloors());

        Vector2 GetWalkerDirection()
        {
            int choice = Mathf.FloorToInt(UnityEngine.Random.value * 3.99f);

            switch (choice)
            {
                case 0:
                    return Vector2.down;
                case 1:
                    return Vector2.left;
                case 2:
                    return Vector2.up;
                case 3:
                    return Vector2.right;
                default:
                    return Vector2.zero;
            }
        }

        IEnumerator CreateFloors()
        {
            while ((float)_tileCount / (float)_gridHandler.Length < _fillPercentage)
            {
                bool hasCreatedFloor = false;
                foreach (Sc_Walker currentWalker in _walkers)
                {
                    Vector3Int currentPos = new Vector3Int((int)currentWalker.walkerPosition.x, (int)currentWalker.walkerPosition.y, 0);

                    if (_gridHandler[currentPos.x, currentPos.y] != Grid.COAL)
                    {
                        _tileMap.SetTile(currentPos, _coal);
                        _tileCount++;
                        _gridHandler[currentPos.x, currentPos.y] = Grid.COAL;
                        hasCreatedFloor = true;
                    }
                }

                ChanceToRemove();
                ChanceToRedirect();
                ChanceToCreate();
                UpdatePosition();

                if (hasCreatedFloor)
                {
                    yield return new WaitForSeconds(_waitTime);
                }
            }

            void ChanceToRemove()
            {
                int updatedCount = _walkers.Count;
                for (int i = 0; i < updatedCount; i++)
                {
                    if (Random.value < _walkers[i].chanceToChange && _walkers.Count > 1)
                    {
                        _walkers.RemoveAt(i);
                        break;
                    }
                }
            }

            void ChanceToRedirect()
            {
                for (int i = 0; i < _walkers.Count; i++)
                {
                    if (Random.value < _walkers[i].chanceToChange)
                    {
                        Sc_Walker curWalker = _walkers[i];
                        currentWalker.walkerDirection = GetWalkerDirection();
                        _walkers[i] = curWalker;
                    }
                }
            }

            void ChanceToCreate()
            {
                int updatedCount = _walkers.Count;
                for (int i = 0; i < updatedCount; i++)
                {
                    if (Random.value < _walkers[i].chanceToChange && _walkers.Count < _maxWalker)
                    {
                        Vector2 newDirection = GetWalkerDirection();
                        Vector2 newPosition = _walkers[i].walkerPosition;

                        Sc_Walker newWalker = new Sc_Walker(newPosition, newDirection, 0.5f);
                        _walkers.Add(newWalker);
                    }
                }
            }

            void UpdatePosition()
            {
                for (int i = 0; i < _walkers.Count; i++)
                {
                    Sc_Walker FoundWalker = _walkers[i];
                    FoundWalker.walkerPosition += FoundWalker.walkerDirection;
                    FoundWalker.walkerPosition.x = Mathf.Clamp(FoundWalker.walkerPosition.x, 1, _gridHandler.GetLength(0) - 2);
                    FoundWalker.walkerPosition.y = Mathf.Clamp(FoundWalker.walkerPosition.y, 1, _gridHandler.GetLength(1) - 2);
                    _walkers[i] = FoundWalker;
                }
            }
        }
    }
}