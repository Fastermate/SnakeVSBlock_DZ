using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image _uiFillImage;
    [SerializeField] public TMP_Text _uiStartText;
    [SerializeField] public TMP_Text _uiFinishText;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _finishTransform;


    private Vector3 _finishPosition;

    private float _fullDistance;

    private void Awake()
    {
        SetLevelTexts(PlayerPrefs.GetInt("LevelIndex", 0));
    }

    private void Start()
    {
        _finishPosition = _finishTransform.position;
        _fullDistance = GetDistance();
    }

    public void SetLevelTexts (int level)
    {
        _uiStartText.text = (level+1).ToString();
        _uiFinishText.text = (level+2).ToString();
    }
    
    private float GetDistance()
    {
        return Vector3.Distance (_playerTransform.position, _finishPosition);
    }

    private void UpdateProgressFill(float value)
    {
        _uiFillImage.fillAmount = value;
    }

    private void Update()
    {
        if (_playerTransform == null) return;
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(_fullDistance, 0f, newDistance);
        UpdateProgressFill(progressValue);
    }
}
