using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [SerializeField] private List<GameObject> _segments;
    [SerializeField] private float _segmentDistanse;
    [SerializeField] private GameObject _segmentPrefab;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private float _speed;

    public void MoveHead(Vector3 direction)
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_speed * Time.fixedDeltaTime);

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    public void MoveTail()
    {
        float sqrDistance = Mathf.Sqrt(_segmentDistanse);
        Vector3 previousPosition = _rigidbody.position;

        foreach (var segment in _tails)
        {
            if ((segment.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                Vector3 currentSegmentPosition = segment.position;
                segment.position = previousPosition;
                previousPosition = currentSegmentPosition;
            }
            else
            {
                break;
            }
        }
    }

    private void Damage()
    {
        _tails.Remove(_tails[0]);
        Destroy(_segments[0]);
        _segments.Remove(_segments[0]);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Eat eat))
        {
            Destroy(eat.gameObject);

            GameObject segment = Instantiate(_segmentPrefab);
            _tails.Add(segment.transform);
            _segments.Add(segment);

        }

        if (other.TryGetComponent(out CubeBarrier cube))
        {
            if (cube.Value < _tails.Count)
            {
                for (int i = 0; i < _tails.Count; i++)
                {
                    Damage();
                    cube.Value--;
                }

            }
            if (cube.Value <= 0)
            {
                Destroy(cube.gameObject);
            }

            if (cube.Value > _tails.Count)
            {
                for(int i = 0; i < cube.Value; i++)
                {
                    Damage();
                    cube.Value--;
                    
                    
                    if (_tails.Count == 0)
                    {
                        break;
                    }
                }
            }

            if (_tails.Count <= 0)
            {
                Debug.Log("Dead");
                Destroy(gameObject);
            }


        }
    }

    


}
