using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesCollector : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _collectionCubes;
    [SerializeField] private Transform _targetCube;

    [SerializeField] private float _heightCube;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CollectingCube cube))
        {
            if (cube.gameObject.transform.parent != _collectionCubes)
            {
                _player.gameObject.transform.position = new Vector3(_player.position.x, _player.position.y + _heightCube, _player.position.z); //перенести в другой классу

                AddCubeToCollection(cube.gameObject);
            }
        }
    }

    private void AddCubeToCollection(GameObject cube)
    {
        cube.gameObject.transform.parent = _collectionCubes; //перенести возможно в другой класс
        cube.transform.localPosition = _targetCube.localPosition;


        _targetCube.localPosition = new Vector3(_targetCube.localPosition.x, _targetCube.localPosition.y - _heightCube, _targetCube.localPosition.z);
    }

}
