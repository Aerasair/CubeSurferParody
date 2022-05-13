using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.Events;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform playerParent;
    [SerializeField] private PathCreator pathCreator;

    public bool IsMoving = false;
    private float distanceTravalled;
    

    private void Update()
    {
        if (IsMoving)
        {
            distanceTravalled += speed * Time.deltaTime;
            playerParent.position = pathCreator.path.GetPointAtDistance(distanceTravalled);
            playerParent.rotation = pathCreator.path.GetRotationAtDistance(distanceTravalled);
        }
    }
}
