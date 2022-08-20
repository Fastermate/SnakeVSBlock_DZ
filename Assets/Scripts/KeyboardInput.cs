using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhisicsMovement _movement;
    [SerializeField] private float _velocity;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        _movement.Move(new Vector3(-_velocity, 0 , horizontal));
    }
}
