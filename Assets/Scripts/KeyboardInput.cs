using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private Player _movement;
    [SerializeField] private float _velocity;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        

        _movement.MoveHead(new Vector3(-_velocity, 0 , horizontal));
        _movement.MoveTail();
    }
}
