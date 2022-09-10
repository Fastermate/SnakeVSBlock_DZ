using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelList _levelsList;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioListener _audioListener;
    
    

    private int _currentLevelIndex;

    private void Awake()
    {
        _currentLevelIndex = _saveLoadSystem.GetLevelIndex();
        _currentLevelIndex %= _levelsList.Levels.Length;


    }


    public void ButtonStart()
    {
        Instantiate(_levelsList.Levels[_currentLevelIndex]);
        _canvas.enabled = false;
        _camera.enabled = false;
        _audioListener.enabled = false;
    }


    public void ButtonRestart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        if( _currentLevelIndex > 2)
        {
            _currentLevelIndex = 0;
        }
        _saveLoadSystem.SaveLevel(_currentLevelIndex);
        Debug.Log(_currentLevelIndex.ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    
}
