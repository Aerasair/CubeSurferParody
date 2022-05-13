using UnityEngine;

public class WallCube : MonoBehaviour
{
    private GameObject lastCube;
    private int hieghtWall = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CubesCollector player))
        {
            if (lastCube != gameObject)
            {
                lastCube = this.gameObject;
                player.RemoveCubeFromCollection();
                hieghtWall++;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        for(int i = 0; i <= hieghtWall; i++)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().TransformDown();     
        }
    }

}
