using UnityEngine;

public class CollectingCube : MonoBehaviour
{
    private GameObject lastCube;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CubesCollector player))
        {
            if (lastCube != gameObject)
            {
                lastCube = this.gameObject;
                player.AddCubeToCollection();
                player.GetComponent<PlayerController>().TransformUP();
                Destroy(this.gameObject);
            }
        }
    }

}
