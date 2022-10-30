using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteCreator : MonoBehaviour
{
    MeshGenerator meshInfo;
    public GameObject[] holds;
    public int[] holdDifficulty;
    //public int index;

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

    private void Start()
    {
        KickOffRec();
    }

    Vector3[] dummyArray = new Vector3[0];
    public void KickOffRec()
    {
        meshInfo = GetComponent<MeshGenerator>();
        dummyArray = new Vector3[meshInfo.vertices.Length];

        int index = 0;
        RecursionMethod(index);
    }

    private class ColorizedSphere
    {
        public Vector3 pos;
        public int color;
    }

    public void RecursionMethod(int input)
    {
        if(input == meshInfo.vertices.Length)
        {
            return;
        }
        var item = meshInfo.vertices[input++];
        Debug.Log("Rec Check");

        

        dummyArray[input] = meshInfo.vertices[input];

        var sphere = Instantiate(holds[1], meshInfo.vertices[input], Quaternion.Euler(0, 0, 0));
        RecursionMethod(input);

        for (int i = 0; i < dummyArray.Length; i++)
        {
            Vector3 location = sphere.transform.position;

        }

    }
 
}
