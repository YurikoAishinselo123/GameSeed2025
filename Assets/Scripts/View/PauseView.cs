using UnityEngine;
using UnityEngine.UI;

public class PauseView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject pauseUIRoot; // The root UI panel or canvas
    [SerializeField] private Button resumeButton;

    [Header("Game State")]
    [SerializeField] private GameStateManager gameStateManager;

    private bool isPaused = false;

    private void Awake()
    {
        pauseUIRoot.SetActive(false);
        resumeButton.onClick.AddListener(OnResumeClicked);
    }

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

        if (isPaused)
        {
            Time.timeScale = 0f;
            gameStateManager.SetState(GameState.Paused);
        }
        else
        {
            Time.timeScale = 1f;
            gameStateManager.SetState(GameState.Gameplay);
        }

        pauseUIRoot.SetActive(isPaused);
    }

    private void OnResumeClicked()
    {
        TogglePause(); // Resume the game
    }
}
