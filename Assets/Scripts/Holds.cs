using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holds : MonoBehaviour
{
    Camera cam;
    public LayerMask layer;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.position);
                transform.position = hit.transform.position;
            }
        }
    }


}
