using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Этот класс наверное наиболее показательный для тебя, видно что нет глобальной идеи, лепишь как получится
//ничего не продумал заранее
//Непонятно чем занимается класс, я бы сказал все подряд, надо разделять зоны ответственности кода
//этот код невозможно будет поддерживать в будущем
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
        // можно переттащить в инспекторе ссылку, гет компонент не юзаем просто так
        playerController = _playerControllerGO.GetComponent<PlayerController>();
    }

    // много чеков непонятных я бы вынес все отдельно в кубы сттены, твои гет компонент объекты
    // они там внутри ждут что с ними столкнется игрок, и потом в игроке дергают чтот им надо
    // либо они ждут столкновения и когда игрок с ними сталкивается, ты в коде игрока вызываешь метод в гет компонент объектах
    // но тотгда нужно юзать наследование и ООП, приколы, хз могешь ты в такое или нет еще
    private void OnCollisionEnter(Collision collision)
    {
        CheckCollectionCubeCollision(collision);

        CheckWallCubeCollision(collision);
    }

    private void CheckCollectionCubeCollision(Collision collision)
    {
        // хорошая проверка мне нравится, маловероятно что можнт сломаться
        if (collision.gameObject.TryGetComponent(out CollectingCube cube))
        {
            // этой проверки у тебя быть не должно, не  заглядывая в юнити вижу проблему, это костыль
            //раздели два вида куба который под игроком и на уровне
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

    // странный метод, мне не нравится как ты все ногами запихал в этот класс
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

        // почему-то всегда перемещаютт куб, не легче было бы его просто удалить и заспавнить новый под игроком
        cube.gameObject.transform.parent = _transformPlayerCollectionCubes; 
        cube.transform.localPosition = new Vector3(0, -1*(_heightCube*(_listCubes.Count()+1)),0);
        cube.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }


    private void RemoveCubeFromCollection()
    {
        // тут ок можно вытаскивать из под родителя, но тотже сомнительно ссмотрится
        CollectingCube cubeCollected = _listCubes.Last();
        // зачем триггер включать? тыпо ты можешь по уровню вернуться и собрать из снова?
        cubeCollected.GetComponent<BoxCollider>().isTrigger = true;

        cubeCollected.gameObject.transform.SetParent(_transformForNoParent);
        _listCubes.Remove(cubeCollected);
    }
}
