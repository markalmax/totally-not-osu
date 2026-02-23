using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputAction Click;
    void Start()
    {
        Click = InputSystem.actions.FindAction("Click");
        Click.performed += context => Onclick();
    }
    void OnEnable()
    {
        Click.Enable();
    }
    void OnDisable()
    {
        Click.Disable();
    }
    void FixedUpdate()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
    public void Onclick()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        Debug.Log(hit.collider);
    }
}
