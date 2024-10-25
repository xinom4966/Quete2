using UnityEngine;

public class Tile
{
    public Vector2 pos { get; private set; } = Vector2.zero;
    public Entity entity;
    public (int, int) gridPos;

    public Tile(Vector2 p_pos, (int, int) p_gridPos)
    {
        this.pos = p_pos;
        this.gridPos = p_gridPos;
    }

    private void SetEntity(Entity p_entity)
    {
        if (!HasEntity())
        {
            this.entity = p_entity;
        }
    }

    private void DeleteEntity(Entity p_entity)
    {
        this.entity = null;
    }

    private bool HasEntity()
    {
        return (entity != null);
    }
}
