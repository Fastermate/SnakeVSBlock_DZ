using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeBarrier : MonoBehaviour
{
    [SerializeField] public int Value;
    [SerializeField] public TextMeshPro ValueText;
    Renderer rend;

    private void Update()
    {
        ValueText.SetText(Value.ToString());
        rend.material.SetFloat("_Step", Value * 0.01f);
    }

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }
}
