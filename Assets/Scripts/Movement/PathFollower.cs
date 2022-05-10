using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower : MonoBehaviour
{
    
    //соблюдай порядок полей везде одинаковый и разделяй логически пустыми сттроками части кода
    // приватные поля не называем с _ зачастую с маленькой бучквы просто, геттеры с большой
    [SerializeField] private float _speed;
    [SerializeField] private Transform _playerParent;

    [SerializeField] private PathCreator _pathCreator;
    private float _distanceTravalled;
    
    private void Update()
    {
        _distanceTravalled += _speed * Time.deltaTime;
        _playerParent.position = _pathCreator.path.GetPointAtDistance(_distanceTravalled);
        _playerParent.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravalled);
    }
}
