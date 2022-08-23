using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeBarrier : MonoBehaviour
{
    [SerializeField] public int Value;
    [SerializeField] public TextMeshPro ValueText;

    private void Update()
    {
        ValueText.SetText(Value.ToString());
    }
}
