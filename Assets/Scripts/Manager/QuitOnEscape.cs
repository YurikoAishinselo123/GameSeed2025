using UnityEngine;

public class QuitOnEscape : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pressed. Quitting...");
            Application.Quit();

#if UNITY_EDITOR
            // If you're in the Unity Editor, stop play mode
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
