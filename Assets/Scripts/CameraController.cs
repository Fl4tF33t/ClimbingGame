using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerPos;
    public MeshGenerator mesh;
    public float zDistance = -12f;
    public float yDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mesh.xSize / 2, playerPos.transform.position.y + yDistance, zDistance);
    }
}
