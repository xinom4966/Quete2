using UnityEngine;

public class Sc_RessourceBehaviour : MonoBehaviour
{
    private float _speed = 1f;

    public float speed
    {
        set
        {
            this._speed = value;
        }

        get
        {
            return this._speed;
        }
    }
    private Bounds _bounds;

    public void MoveLeft()
    {
        Vector3 nextPosition = new Vector3(
            this.transform.position.x - this.speed * Time.deltaTime,
            this.transform.position.y,
            this.transform.position.z
        );

        this.transform.position = nextPosition;
    }
}
