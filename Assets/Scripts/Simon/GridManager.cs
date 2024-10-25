using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private List<List<Tile>> _grid = new List<List<Tile>>();
    [SerializeField] private int _gridWidth;
    [SerializeField] private int _gridHeight;
    [SerializeField] private int _tileSpacement;
    [SerializeField] private Transform _gridCenter;

    private void Start()
    {
        GridCreation();
    }

    private void GridCreation()
    {
        for (int i = 0; i < _gridWidth; i++)
        {
            _grid.Add(new());
            for (int j = 0; j < _gridHeight; j++)
            {
                Tile tile = new(new Vector2(_gridCenter.position.x + (i - (_gridWidth - 1) / 2) * _tileSpacement, _gridCenter.position.y + (j - (_gridHeight - 1) / 2) * _tileSpacement), (i, j));
                _grid[i].Add(tile);
            }
        }
    }

    private Tile GetTile(int p_x, int p_y)
    {
        if (p_x < _grid.Count && p_y < _grid[0].Count && p_x >= 0 && p_y >= 0)
        {
            return _grid[p_x][p_y];
        }
        else
        {
            return null;
        }
    }

    public Tile GetClosestTile(Vector3 p_position)
    {
        Tile closestTile = null;
        float distanceMinimum = float.MaxValue;

        for (int i = 0; i < _gridWidth; i++)
        {
            for (int j = 0; j < _gridHeight; j++)
            {
                if (Vector3.Distance(p_position, _grid[i][j].pos) < distanceMinimum)
                {
                    closestTile = _grid[i][j];
                    distanceMinimum = Vector3.Distance(p_position, _grid[i][j].pos);
                }
            }
        }
        return closestTile;
    }

    public List<Tile> GetNeighbors(Tile p_testedTile)
    {
        List<Tile> neighbors = new();

        var front = GetTile(p_testedTile.gridPos.Item1, p_testedTile.gridPos.Item2 + 1);
        var back = GetTile(p_testedTile.gridPos.Item1, p_testedTile.gridPos.Item2 - 1);
        var right = GetTile(p_testedTile.gridPos.Item1 + 1, p_testedTile.gridPos.Item2);
        var left = GetTile(p_testedTile.gridPos.Item1 - 1, p_testedTile.gridPos.Item2);

        if (front != null) neighbors.Add(front);
        if (back != null) neighbors.Add(back);
        if (right != null) neighbors.Add(right);
        if (left != null) neighbors.Add(left);

        return neighbors;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < _grid.Count; i++)
        {
            foreach (Tile tile in _grid[i])
            {
                Gizmos.DrawSphere(tile.pos, 0.1f);
            }
        }
    }
}
