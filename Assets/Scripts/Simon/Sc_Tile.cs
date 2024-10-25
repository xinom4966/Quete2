using UnityEngine;

public class Sc_Tile
{
    public Vector2 pos { get; private set; } = Vector2.zero;
    public Sc_Entity entity;
    public (int, int) gridPos;

    public Sc_Tile(Vector2 p_pos, (int, int) p_gridPos)
    {
        this.pos = p_pos;
        this.gridPos = p_gridPos;
    }

    private void SetEntity(Sc_Entity p_entity)
    {
        if (!HasEntity())
        {
            this.entity = p_entity;
        }
    }

    private void DeleteEntity(Sc_Entity p_entity)
    {
        this.entity = null;
    }

    private bool HasEntity()
    {
        return (entity != null);
    }
}
