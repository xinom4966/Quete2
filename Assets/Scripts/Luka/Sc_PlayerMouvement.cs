using UnityEngine;
using UnityEngine.InputSystem;

public class Sc_PlayerMouvement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 30f;
    private Vector2 _position = new Vector2();
    [SerializeField] private GameObject _inventoryDisplay;
    [SerializeField] private int _inventorySizeX;
    [SerializeField] private int _inventorySizeY;
    private Sc_Inventory _playerInventory;
    private Sc_InventoryDisplay _inventoryDisplayScript;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInventory = new Sc_Inventory(_inventorySizeX, _inventorySizeY);
        _inventoryDisplayScript = _inventoryDisplay.GetComponent<Sc_InventoryDisplay>();
    }

    private void Update()
    {
        Move();
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
        float step = _speed * Time.deltaTime;
        Vector2 newPos = (Vector2)transform.position + _position;
        transform.position = Vector2.MoveTowards(transform.position, newPos, step);

    }

    public void OpenAndCloseInventory()
    {
        _inventoryDisplayScript.SetInventoryRef(_playerInventory);
        _inventoryDisplay.SetActive(!_inventoryDisplay.activeSelf);
    }
}
