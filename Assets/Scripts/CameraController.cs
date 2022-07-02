using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private Transform _playerBody;
    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void Update()
    {
        float mousePositionX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mousePositionY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
    
        _xRotation -= mousePositionY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _playerBody.Rotate(Vector3.up * mousePositionX);
    }   
}