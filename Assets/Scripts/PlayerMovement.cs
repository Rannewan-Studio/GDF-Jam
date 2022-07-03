using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    private Vector3 _velocity;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;

    [Header("GroundCheck")]
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckRadius;

    [Header("Other")]
    [SerializeField] private CharacterController _controller;

    private void FixedUpdate()
    {
        Move();
        Jump();
        Fall();
    }

    private void Move()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * xDirection + transform.forward * zDirection;
        _controller.Move(moveDirection * _moveSpeed * Time.deltaTime);

        if(xDirection != 0 || zDirection != 0)
        {
            AudioPlayer.Instance.PlayAudio(3);
        }
    }

    public void Jump()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(IsGrounded() == true)
            {
                _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravityScale);
            }
        }
    }

    private void Fall()
    {
        if(IsGrounded() == true && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _velocity.y += _gravityScale * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheckPoint.position, _groundCheckRadius, _groundLayer);
    }
}
