using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerInputActions inputSystem;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        inputSystem = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputSystem.Enable();

        inputSystem.UI.Pause.performed += OnPauseInput;
    }

    private void OnDisable()
    {
        inputSystem.UI.Pause.performed -= OnPauseInput;
        inputSystem.Disable();
    }

    private void OnPauseInput(InputAction.CallbackContext context)
    {
        PauseEvents.RaisePause();
    }
}
