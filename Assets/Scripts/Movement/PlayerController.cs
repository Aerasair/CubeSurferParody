using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbodyPlayer;
    [SerializeField] private Rigidbody _rbCamera;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _leftRightSpeed;
    [SerializeField] private float _forwardSpeed;

    [SerializeField] private float _roadWidth;

    private void FixedUpdate()
    {
        _rbCamera.velocity = new Vector3(_rbCamera.velocity.x, _rbCamera.velocity.y, _forwardSpeed-0.1f);

        Vector3 nextPosition = new Vector3(_joystick.Horizontal * _leftRightSpeed, _rigidbodyPlayer.velocity.y, _forwardSpeed);
        if (CheckIsBound(_rigidbodyPlayer.transform.position.x, _joystick.Horizontal))
            _rigidbodyPlayer.velocity = nextPosition;
        else
              _rigidbodyPlayer.velocity = new Vector3(0, 0, _forwardSpeed); ;
    }

    private bool CheckIsBound(float nextPositionX, float horizontal)
    {
        bool value = false;

        if (nextPositionX > -_roadWidth && horizontal < 0) //can move left while true
            return true;
        if (nextPositionX < _roadWidth && horizontal > 0) //can move right while true
            return true;

        return value;
    }
    
    public void UpPositionPlayer(float heightCube)
    {
        _rigidbodyPlayer.transform.position = new Vector3(_rigidbodyPlayer.transform.position.x, _rigidbodyPlayer.transform.position.y + heightCube, _rigidbodyPlayer.transform.position.z);
    }

    public void DownPositionPlayer(int countCubes, float heightCube)
    {
        _rigidbodyPlayer.transform.position = new Vector3(_rigidbodyPlayer.transform.position.x, countCubes * heightCube + heightCube, _rigidbodyPlayer.transform.position.z);
    }
}
