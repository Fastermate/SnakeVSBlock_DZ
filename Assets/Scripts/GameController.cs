using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private KeyboardInput _keyboardInput;
    [SerializeField] private Canvas _canvasLose;
    [SerializeField] private Canvas _canvasWin;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _loseSound;

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
        _canvasLose.enabled = true;
        _loseSound.Play();
        Debug.Log("Game Over!");
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        _canvasWin.enabled = true;
        _keyboardInput.enabled = false;
        _winSound.Play();
        Debug.Log("You Won!");
    }
}
