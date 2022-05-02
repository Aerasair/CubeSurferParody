using PathCreation;
using UnityEngine;

public class FollowerPath : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _speedForward;
    [SerializeField] private float _distanceTravelled;

    private void Update()
    {
        //_distanceTravelled += _speedForward * Time.deltaTime;
        //transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled);
        //transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
    }

}
