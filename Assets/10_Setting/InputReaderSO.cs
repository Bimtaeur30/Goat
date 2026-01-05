using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInput;

[CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
public class InputReaderSO : ScriptableObject, IPlayerActions
{
    private PlayerInput _controls;
    public Vector2 Movement { get; private set; }
    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new PlayerInput();
        }
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }
    private void OnDisable()
    {
        _controls.Player.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();

    }
}
