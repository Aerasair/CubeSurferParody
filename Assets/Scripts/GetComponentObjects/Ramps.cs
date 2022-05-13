using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramps : MonoBehaviour
{
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out CubesCollector player))
        {
            player.RemoveCubeFromCollection();
        }
    }
}
