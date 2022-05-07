using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesCollector : MonoBehaviour
{
    [SerializeField] private GameObject _playerControllerGO;
    [SerializeField] private Transform _transformPlayerCollectionCubes;
    [SerializeField] private Transform _transformForNoParent;

    [SerializeField] private float _heightCube;

    [SerializeField] private List<CollectingCube> _listCubes = new List<CollectingCube>();

    private PlayerController playerController;

    private void Start()
    {
        playerController = _playerControllerGO.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckCollectionCubeCollision(collision);

        CheckWallCubeCollision(collision);
    }

    private void CheckCollectionCubeCollision(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CollectingCube cube))
        {
            if (cube.gameObject.transform.parent != _transformPlayerCollectionCubes)
            {
                playerController.PlayerUPByCubes(_listCubes.Count(), _heightCube);
                AddCubeToCollection(cube);
            }
        }
    }

    private void CheckWallCubeCollision(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out WallCube wallCube))
        {
            if (wallCube.enabled)
            {
                RemoveCubeFromCollection();
                wallCube.GetComponent<WallCube>().enabled = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out WallCube wallCube))
            playerController.PlayerDown(_listCubes.Count, _heightCube);

        if (collision.gameObject.TryGetComponent(out Ramps ramp))
        {
            playerController.PlayerUPByTransform(_heightCube);
            RemoveCubeFromCollection();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out WallCube wallCube))
            playerController.PlayerDown(_listCubes.Count, _heightCube);
    }

    private void AddCubeToCollection(CollectingCube cube)
    {
        _listCubes.Add(cube);

        cube.gameObject.transform.parent = _transformPlayerCollectionCubes; 
        cube.transform.localPosition = new Vector3(0, -1*(_heightCube*(_listCubes.Count()+1)),0);
        cube.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }


    private void RemoveCubeFromCollection()
    {
        CollectingCube cubeCollected = _listCubes.Last();

        cubeCollected.GetComponent<BoxCollider>().isTrigger = true;

        cubeCollected.gameObject.transform.SetParent(_transformForNoParent);
        _listCubes.Remove(cubeCollected);
    }
}
