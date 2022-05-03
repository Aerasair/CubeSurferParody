using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesCollector : MonoBehaviour
{
    [SerializeField] private GameObject _playerControllerGO;
    [SerializeField] private Transform _collectionCubes;
    [SerializeField] private Transform _targetCube;
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
        if (collision.gameObject.TryGetComponent(out CollectingCube cube))
        {
            if (cube.gameObject.transform.parent != _collectionCubes)
            {
                playerController.UpPositionPlayer(_heightCube);
                AddCubeToCollection(cube);
            }
        }

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
            playerController.DownPositionPlayer(_listCubes.Count, _heightCube);
    }

  

    private void AddCubeToCollection(CollectingCube cube)
    {
        cube.gameObject.transform.parent = _collectionCubes; 
        cube.transform.localPosition = _targetCube.localPosition;

        _targetCube.localPosition = new Vector3(_targetCube.localPosition.x, _targetCube.localPosition.y - _heightCube, _targetCube.localPosition.z);

        _listCubes.Add(cube);
    }

    private void RemoveCubeFromCollection()
    {
        CollectingCube cubeCollected = _listCubes.Last();
        _listCubes.Last().GetComponent<BoxCollider>().isTrigger = true;

        cubeCollected.gameObject.transform.SetParent(_transformForNoParent);

        _targetCube.localPosition = new Vector3(_targetCube.localPosition.x, _targetCube.localPosition.y + _heightCube, _targetCube.localPosition.z);

        _listCubes.Remove(cubeCollected);
    }


}
