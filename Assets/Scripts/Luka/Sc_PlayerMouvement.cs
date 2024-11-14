using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

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

    //This drill is only for debugging purposes !
    [SerializeField] private GameObject _drillPrefab;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inventoryDisplayScript = _inventoryDisplay.GetComponentInChildren<Sc_InventoryDisplay>();
        _playerInventory = new Sc_Inventory(_inventoryDisplayScript.gameObject, _inventorySizeX, _inventorySizeY);
    }

    //This start is only for debugging purposes at the moment !
    private void Start()
    {
        _playerInventory.AddToStorage(_drillPrefab.GetComponent<Sc_Drill>());
    }

    private void Update()
    {
        Move();
        Interact();
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

    private void Interact()
    {

    }
}
