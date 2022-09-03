using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private KeyboardInput _keyboardInput;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        _keyboardInput.enabled = false;
        
        Debug.Log("Game Over!");
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        
        _keyboardInput.enabled = false;
        Debug.Log("You Won!");
    }
}
