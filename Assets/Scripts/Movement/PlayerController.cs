using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _leftRightSpeed;
    [SerializeField] private float _forwardSpeed;

    [SerializeField] private Rigidbody _rbCamera;


    [SerializeField] private Transform _boundItem;
    [SerializeField] private float _roadWidth;


    private void FixedUpdate()
    {
        _rbCamera.velocity = new Vector3(_rbCamera.velocity.x, _rbCamera.velocity.y, _forwardSpeed);

        Vector3 nextPosition = new Vector3(_joystick.Horizontal * _leftRightSpeed, _rigidbody.velocity.y, _forwardSpeed);
        if (CheckIsBound(_rigidbody.transform.position.x, _joystick.Horizontal))
            _rigidbody.velocity = nextPosition;
        else
              _rigidbody.velocity = new Vector3(0, 0, _forwardSpeed); ;

    }

    private bool CheckIsBound(float nextPositionX, float horizontal)
    {
        bool value = false;

        if (nextPositionX > -1.80f && horizontal < 0) //можем двигаться влево пока тру
            return true;
        if (nextPositionX < 1.80f && horizontal > 0) //можем двигаться вправо пока тру
            return true;

        return value;
    }
}
