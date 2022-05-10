using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbodyPlayer;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _leftRightSpeed;

    [SerializeField] private float _roadWidth;

    private float _heightPlayerModel = 0.5f;

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
            //фигурные скобки верни
        if (nextPositionX > -_roadWidth && horizontal < 0) //can move left while true
            return true;
        if (nextPositionX < _roadWidth && horizontal > 0) //can move right while true
            return true;

        return value;
    }
    
    public void PlayerUPByCubes(int countCubes, float heightCube)
    {
        // почему через рб, ты тут функционал рб вообзе не юзаешь, делай тип трансформ
        // расчет Y я бы вынес в переменную чтобы строка было короче
        // везде пробелы а плюсу пробела пожадничал, упращай чтение кода с помощью его чистоты
        _rigidbodyPlayer.transform.position = new Vector3(_rigidbodyPlayer.transform.position.x, ((countCubes + 1) * heightCube) + heightCube+  _heightPlayerModel, _rigidbodyPlayer.transform.position.z);
    }

    public void PlayerUPByTransform(float heightCube)
    {
        // бесполезный метод, он ничего не делает
        _rigidbodyPlayer.transform.position = new Vector3(_rigidbodyPlayer.transform.position.x, _rigidbodyPlayer.transform.position.y, _rigidbodyPlayer.transform.position.z);
    }

    // что с неймингом, почему не DownByCubes
    // и вообще имя странное, ну да ладно
    public void PlayerDown(int countCubes, float heightCube)
    {
        _rigidbodyPlayer.transform.position = new Vector3(_rigidbodyPlayer.transform.position.x, ((countCubes + 1) * heightCube) - heightCube + _heightPlayerModel, _rigidbodyPlayer.transform.position.z);
    }


}
