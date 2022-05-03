using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesCollector : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _collectionCubes;
    [SerializeField] private Transform _targetCube;

    [SerializeField] private Transform _transformForNoParent;

    [SerializeField] private float _heightCube;

    [SerializeField] private List<CollectingCube> listCubes = new List<CollectingCube>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CollectingCube cube))
        {
            if (cube.gameObject.transform.parent != _collectionCubes)
            {
                UpdatePosPlayer(_heightCube);
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

    private void AddCubeToCollection(CollectingCube cube)
    {
        cube.gameObject.transform.parent = _collectionCubes; 
        cube.transform.localPosition = _targetCube.localPosition;

        _targetCube.localPosition = new Vector3(_targetCube.localPosition.x, _targetCube.localPosition.y - _heightCube, _targetCube.localPosition.z);

        listCubes.Add(cube);
    }

    private void RemoveCubeFromCollection()
    {
        CollectingCube cubeCollected = listCubes.Last();
        listCubes.Last().GetComponent<BoxCollider>().isTrigger = true;

        cubeCollected.gameObject.transform.SetParent(_transformForNoParent);

        _targetCube.localPosition = new Vector3(_targetCube.localPosition.x, _targetCube.localPosition.y + _heightCube, _targetCube.localPosition.z);

        listCubes.Remove(cubeCollected);
    }

    //перенести в другой класс
    private void UpdatePosPlayer(float heightCube)//только вверх работает
    {
        _player.gameObject.transform.position = new Vector3(_player.position.x, _player.position.y + heightCube, _player.position.z); 
    }

}
