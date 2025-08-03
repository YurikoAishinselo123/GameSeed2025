using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    
    private void OnEnable()
    {
        PauseEvents.OnPauseRequested += TogglePause;
    }

    private void OnDisable()
    {
        PauseEvents.OnPauseRequested -= TogglePause;
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        Debug.Log("Game Paused: " + isPaused);
    }
}
