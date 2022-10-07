using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteCreator : MonoBehaviour
{
    MeshGenerator meshInfo;
    public GameObject[] holds;
    public int[] holdDifficulty;
    
    // Start is called before the first frame update
    public void StartRouteCreation()
    {
        meshInfo = GetComponent<MeshGenerator>();
        int routeSize = Random.Range(15, meshInfo.vertices.Length / 2);
        holdDifficulty = new int[routeSize];
        for (int i = 0; i < routeSize; i++)
        {
            int prefabIndex = Random.Range(0, 4);
            int randIndex = Random.Range(meshInfo.xSize, meshInfo.vertices.Length);
            Instantiate(holds[prefabIndex], meshInfo.vertices[randIndex], Quaternion.Euler(0, 0, 0));
            holdDifficulty[i] = prefabIndex;
        }
    }
 
}
