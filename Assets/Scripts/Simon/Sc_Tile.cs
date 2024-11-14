using UnityEngine;

public class Sc_Tile<T> where T : class
{
    public Vector2 pos { get; private set; } = Vector2.zero;
    public (int, int) gridPos;
    private T entity;

    public Sc_Tile(Vector2 p_pos, (int, int) p_gridPos)
    {
        this.pos = p_pos;
        this.gridPos = p_gridPos;
    }

    public void SetEntity(T p_entity)
    {
        if (!HasEntity())
        {
            this.entity = p_entity;
        }
    }

    public void DeleteEntity(T p_entity)
    {
        this.entity = null;
    }

    public bool HasEntity()
    {
        return (entity != null);
    }

    public T GetEntity()
    {
        if (HasEntity())
        {
            return entity;
        }
        return null;
    }
}
