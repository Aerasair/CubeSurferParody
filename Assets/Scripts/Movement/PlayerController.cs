using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject objectPlayer;
    [SerializeField] private float heightCube;

    private int countCubes;

    private void Start()
    {
        TransformUP();
    }

    private void PlayerUpdateTransform()
    {
        var newYPos = (countCubes * heightCube);
        objectPlayer.transform.localPosition = new Vector3(objectPlayer.transform.localPosition.x, newYPos, objectPlayer.transform.localPosition.z);
    }

    public void TransformUP()
    {
        countCubes++;
        PlayerUpdateTransform();
    }

    public void TransformDown()
    {
        countCubes--;
        PlayerUpdateTransform();
    }

}
