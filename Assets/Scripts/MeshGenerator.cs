using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    public GameObject[] holds;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;

    public int xSize;
    public int ySize;
    public int routeSize;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh =  mesh;

        xSize = Random.Range(12, 28);
        ySize = Random.Range(17, 38);
        CreateShape();
        UpdateMesh();
        ClimableRoute();

    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];

        
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize ; x++)
            {
                float z = Mathf.PerlinNoise(x * .3f, y * .3f) * 2.5f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[(xSize * ySize * 6)];

        int vert = 0;
        int tris = 0;

        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }

        uvs = new Vector2[vertices.Length];

        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                uvs[i] = new Vector2((float)x / (xSize / 2), (float)y / (ySize/2));
                i++;
            }
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;
        
        for (int i = 0; i < vertices.Length; i++)
        {
             Gizmos.DrawSphere(vertices[i], .1f);
        }


    }

    void ClimableRoute()
    {
        routeSize = Random.Range(15, 60);
        Debug.Log(vertices.Length);
        Debug.Log(routeSize);
        for (int i = 0; i < routeSize; i++)
        {
            int randIndex = Random.Range(xSize, vertices.Length);
            Debug.Log(randIndex);
            //climableRoute[i] = rand;
            Debug.Log(vertices[randIndex]);
            Instantiate(holds[Random.Range(0, 4)], vertices[randIndex], Quaternion.Euler(0,0,0));
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        

    }
}
