using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speedForward;

    private void FixedUpdate()
        {
        //_rigidbody.velocity = new Vector3(0, 0, _speedForward);
        }
   
}
