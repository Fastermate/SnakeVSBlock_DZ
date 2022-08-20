using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smooth = 5.0f;
    [SerializeField] private Vector3 _offset;
   
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp (transform.position, _target.position + _offset,Time.deltaTime * _smooth);
    }
}
