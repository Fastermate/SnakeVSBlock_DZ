using UnityEngine;
using UnityEngine.UI;

public class BlockValueText : MonoBehaviour
{
    [SerializeField] private CubeBarrier _barrier;
    [SerializeField] private Text _barrierText;

    private void Update()
    {
        _barrierText.text = _barrier.Value.ToString();
    }
}
