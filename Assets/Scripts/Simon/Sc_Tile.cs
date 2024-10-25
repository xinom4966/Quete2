using UnityEngine;

public class Sc_Tile<T> where T : class
{
    public Vector2 pos { get; private set; } = Vector2.zero;
    public (int, int) gridPos;
    public T entity;

    public Sc_Tile(Vector2 p_pos, (int, int) p_gridPos)
    {
        this.pos = p_pos;
        this.gridPos = p_gridPos;
    }

    private void SetEntity(T p_entity)
    {
        if (!HasEntity())
        {
            this.entity = p_entity;
        }
    }

    private void DeleteEntity(T p_entity)
    {
        this.entity = null;
    }

    private bool HasEntity()
    {
        return (entity != null);
    }
}
