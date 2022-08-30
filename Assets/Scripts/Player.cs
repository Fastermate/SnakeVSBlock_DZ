using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private GameController _controller;
    [SerializeField] private TextMeshPro _snakeScore;
    

    

    private void Start()
    {
        GameObject segment = Instantiate(_segmentPrefab);
        _tails.Add(segment.transform);
        _segments.Add(segment);

        
    }

    private void Update()
    {
        _snakeScore.SetText(_tails.Count.ToString());
    }

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
            if ((segment.position - previousPosition.normalized).sqrMagnitude > sqrDistance)
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
            StartCoroutine(DamageTimer());

            IEnumerator DamageTimer()
            {
                do
                {
                    cube.Value--;
                    Damage();
                    yield return new WaitForSeconds(0.1f);
                }
                while(cube.Value != 0 && _tails.Count != 0);
                if (_tails.Count <= 0)
                {
                    Die();
                }
                if (cube.Value <= 0)
                {
                    Destroy(cube.gameObject);
                }
                StopAllCoroutines();
            }
            
        }
    }

    public void Die()
    {
        _controller.OnPlayerDied();
        _rigidbody.velocity = Vector3.zero;
        Destroy(gameObject);
    }
    public void ReachFinish()
    {
        _controller.OnPlayerReachedFinish();
        
    }
}
