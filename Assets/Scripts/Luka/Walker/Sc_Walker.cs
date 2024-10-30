using UnityEngine;

public class Sc_Walker
{
    public Vector2 walkerPosition;
    public Vector2 walkerDirection;

    public float chanceToChange;

    public Sc_Walker(Vector2 p_walkerPosition, Vector2 p_walkerDirection, float p_chanceToChange)
    {
        walkerPosition = p_walkerPosition;
        walkerDirection = p_walkerDirection;
        chanceToChange = p_chanceToChange;
    }
}
