using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteCreator : MonoBehaviour
{
    MeshGenerator meshInfo;
    public GameObject[] holds;
    int[] holdDifficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        meshInfo = GetComponent<MeshGenerator>();
        Invoke("RouteCreation", 1f);
        Debug.Log(meshInfo.vertices.Length);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void RouteCreation()
    {
        int routeSize = Random.Range(15, meshInfo.vertices.Length/2);
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
