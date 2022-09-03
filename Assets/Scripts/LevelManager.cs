using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelList _levelsList;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;
    [SerializeField] private Canvas _canvas;
    
    

    private int _currentLevelIndex;

    private void Awake()
    {
        _currentLevelIndex = _saveLoadSystem.GetLevelIndex();
        _currentLevelIndex %= _levelsList.Levels.Length;
        Instantiate(_levelsList.Levels[_currentLevelIndex]);
        
        
    }
    

    private void Update()
    {
        


        //if (PlayerPrefs.GetInt("PlayerSate") == 1)
        //{
        //    LoadNextLevel();
        //}
    }
    

    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        _saveLoadSystem.SaveLevel(_currentLevelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _canvas.enabled = false;
    }

    
}
