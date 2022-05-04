using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbodyPlayer;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _leftRightSpeed;

    [SerializeField] private float _roadWidth;

    private void FixedUpdate()
    {
        Vector3 nextPosition = new Vector3(_joystick.Horizontal * _leftRightSpeed, _rigidbodyPlayer.velocity.y, 0);
        if (CheckIsBound(_rigidbodyPlayer.transform.position.x, _joystick.Horizontal))
            _rigidbodyPlayer.velocity = nextPosition;
        else
              _rigidbodyPlayer.velocity = new Vector3(0, 0, 0); 
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
    
    public void PlayerUP(int countCubes, float heightCube)
    {
        _rigidbodyPlayer.transform.position = new Vector3(_rigidbodyPlayer.transform.position.x, ((countCubes + 1) * heightCube)+heightCube+0.5f, _rigidbodyPlayer.transform.position.z);
    }


    public void PlayerDown(int countCubes, float heightCube)
    {
        _rigidbodyPlayer.transform.position = new Vector3(_rigidbodyPlayer.transform.position.x, ((countCubes + 1) * heightCube) - heightCube + 0.5f, _rigidbodyPlayer.transform.position.z);
    }


}
