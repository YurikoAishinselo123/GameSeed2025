using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    private bool isCursorVisible = false;
    // Name of the main menu scene to load
    [Tooltip("Name of the main menu scene to load when returning from pause menu")]
    public string mainMenuSceneName;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameIsPaused)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f; // Pause the game  
            isCursorVisible = !isCursorVisible;
            Cursor.lockState = isCursorVisible ? CursorLockMode.None : CursorLockMode.Locked; // Toggle cursor lock state
            Cursor.visible = true; // Show the cursor
            GameIsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GameIsPaused)
        {
            ResumeButton();
        }
    }

    public void ResumeButton()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        Cursor.visible = false; // Hide the cursor
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        isCursorVisible = false;
        GameIsPaused = false;
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
    }
}
