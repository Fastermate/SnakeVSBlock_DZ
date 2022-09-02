using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelList _levelsList;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;
    

    private int _currentLevelIndex;

    private void Awake()
    {
        _currentLevelIndex = _saveLoadSystem.GetLevelIndex();
        _currentLevelIndex %= _levelsList.Levels.Length;
        var level = Instantiate(_levelsList.Levels[_currentLevelIndex]);
        level.GetComponent<ProgressBarUI>().SetLevelTexts(_currentLevelIndex);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        _currentLevelIndex++;
        _saveLoadSystem.SaveLevel(_currentLevelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
