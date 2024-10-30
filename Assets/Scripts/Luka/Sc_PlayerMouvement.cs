using UnityEngine;
using UnityEngine.InputSystem;

public class Sc_PlayerMouvement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 5f;
    private Vector2 _position = new Vector2();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        PlaceBuildings();
    }

    public void Mouvement(InputAction.CallbackContext p_ctx)
    {
        if (p_ctx.performed)
        {
            _position = p_ctx.ReadValue<Vector2>();
        }

        else if (p_ctx.canceled)
        {
            _position = Vector2.zero;
            return;
        }
    }

    private void Move()
    {
        //_rb.AddForce(new Vector2(_position.x, _position.y) * _speed, ForceMode2D.Force);
        float step = _speed * Time.deltaTime;
        Vector2 newPos = (Vector2)transform.position + _position;
        transform.position = Vector2.MoveTowards(transform.position, newPos, step);

    }

    private void PlaceBuildings()
    {

    }
}
