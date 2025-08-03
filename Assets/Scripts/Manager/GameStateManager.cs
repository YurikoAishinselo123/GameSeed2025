using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    public GameState CurrentState { get; private set; }
    public GameState PreviousState { get; private set; }

    public event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetState(GameState newState)
    {
        if (CurrentState == newState) return;

        PreviousState = CurrentState;
        CurrentState = newState;
        Debug.Log($"GameState changed from {PreviousState} to {CurrentState}");
        OnGameStateChanged?.Invoke(newState);

        Time.timeScale = (newState == GameState.Paused) ? 0 : 1;
    }

    public void ResumePreviousState()
    {
        SetState(PreviousState);
    }
}


