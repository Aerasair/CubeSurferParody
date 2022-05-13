using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesCollector : MonoBehaviour
{
    [SerializeField] private Transform transformPlayerCollectionCubes;
    [SerializeField] private Transform transformForNoParent;
   // [SerializeField] private PlayerController playerController;
    [SerializeField] private List<CollectingCube> listCubes = new List<CollectingCube>();
    [SerializeField] private CollectingCube prefabOrangeCube;

    [SerializeField] private float heightCube;


    public void AddCubeToCollection()
    {
        CollectingCube cube =  Instantiate(prefabOrangeCube);
        listCubes.Add(cube);

        cube.transform.SetParent(transformPlayerCollectionCubes);
        cube.transform.localPosition = new Vector3(0, -1*(heightCube*(listCubes.Count()+1)),0);
        cube.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }


    public void RemoveCubeFromCollection()
    {
        if (listCubes.Count() > 0)
        {
            CollectingCube cubeCollected = listCubes.Last();
            cubeCollected.gameObject.transform.SetParent(transformForNoParent);
            Destroy(cubeCollected.gameObject.GetComponent<CollectingCube>());
            listCubes.Remove(cubeCollected);
        }

    }

}
