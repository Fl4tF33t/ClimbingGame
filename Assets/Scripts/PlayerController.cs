using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    MeshGenerator meshInfo;
    public LayerMask layer;
    public GameObject lHand;
    public GameObject rHand;
    public GameObject lFoot;
    public GameObject rFoot;
    Vector3 handOffset = new Vector3(0, 0, 0);
    public float armRange = 5f;
    public float legRange = 5f;
    bool isJumping = false;
    int holds;

    // Start is called before the first frame update
    void Start()
    {
        //finding the Raycast of the holds
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //finding the first spawned vertice
        //meshInfo = GameObject.Find("Mesh Generator").GetComponent<MeshGenerator>().vertices;
        //placing the transform near the first vertice
        //transform.position = meshInfo[1] + new Vector3(2, 0, 6);

    }

    // Update is called once per frame
    void Update()
    {
        //Moving the left hand
        MovingLeftHand();
        MovingRightHand();
        MovingLeftFoot();
        MovingRightFoot();
        Jumping();
    }

    void MovingLeftHand()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float yDifference = hit.transform.position.y - transform.position.y;
                float xDifference = hit.transform.position.x - transform.position.x;

                holds = hit.transform.gameObject.GetComponent<Difficulty>().difficulty;

                if(holds >= 0)
                {
                    if (hit.transform.position.x - rHand.transform.position.x <= 1)
                    {
                        if (yDifference < armRange && yDifference > -armRange && xDifference < armRange && xDifference > -armRange)
                        {
                            lHand.transform.position = hit.transform.position + handOffset;
                            transform.position = CentrePoint();
                            Debug.Log(HoldCheck(hit));
                        }
                    }
                }
                
            }
        }
    }

    float CheckPosition(RaycastHit hit)
    {
        float[] values = new float[2];
        float yDifference = hit.transform.position.y - transform.position.y;
        float xDifference = hit.transform.position.x - transform.position.x;
        return values
    }
    
    void MovingRightHand()
    {
        if (Input.GetMouseButtonDown(1))
        { 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float yDifference = hit.transform.position.y - transform.position.y;
                float xDifference = hit.transform.position.x - transform.position.x;

                if (lHand.transform.position.x - hit.transform.position.x <= 1)
                {
                    if (yDifference < armRange && yDifference > -armRange && xDifference < armRange && xDifference > -armRange)
                    {
                        rHand.transform.position = hit.transform.position + handOffset;
                        transform.position = CentrePoint();
                    }
                }
            }
        }
    }

    void MovingLeftFoot()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float yDifference = hit.transform.position.y - transform.position.y;
                float xDifference = hit.transform.position.x - transform.position.x;

                if (hit.transform.position.x - rFoot.transform.position.x <= 1)
                {
                    if (yDifference < armRange && yDifference > -armRange && xDifference < armRange && xDifference > -armRange)
                    {
                        lFoot.transform.position = hit.transform.position + handOffset;
                        transform.position = CentrePoint();

                    }
                }
            }
        }
    }

    void MovingRightFoot()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float yDifference = hit.transform.position.y - transform.position.y;
                float xDifference = hit.transform.position.x - transform.position.x;


                if (lFoot.transform.position.x - hit.transform.position.x <= 1)
                {
                    if (yDifference < armRange && yDifference > -armRange && xDifference < armRange && xDifference > -armRange)
                    {
                        rFoot.transform.position = hit.transform.position + handOffset;
                        transform.position = CentrePoint();
                    }
                }
            }
        }
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            float lDifference = lHand.transform.position.y - lFoot.transform.position.y;
            float rDifference = rHand.transform.position.y - rFoot.transform.position.y; ;
            if (lDifference < 7 && rDifference < 7)
            {
                StartCoroutine(StartJumping());
            }
            
        }
    }

    IEnumerator StartJumping()
    {
        isJumping = true;
        if(lHand.transform.position.y >= rHand.transform.position.y)
        {
            float yValue = lHand.transform.position.y - transform.position.y;
            float xValue = lHand.transform.position.x - transform.position.x;
            transform.position += new Vector3(xValue, yValue, 0);
        }
        else if (lHand.transform.position.y <= rHand.transform.position.y)
        {
            float yValue = rHand.transform.position.y - transform.position.y;
            float xValue = rHand.transform.position.x - transform.position.x;
            transform.position += new Vector3(xValue, yValue, 0);
        }
        yield return new WaitForSeconds(3f);
        transform.position = CentrePoint();
        isJumping = false;

    }
    Vector3 CentrePoint()
    {
        
        float xValue = (lHand.transform.position.x + rHand.transform.position.x + lFoot.transform.position.x + rFoot.transform.position.x) / 4;
        float yValue = (lHand.transform.position.y + rHand.transform.position.y + lFoot.transform.position.y + rFoot.transform.position.y) / 4;
        Vector3 centerPoint = new Vector3(xValue, yValue, -1);
        return centerPoint; 
    }

    int HoldCheck(RaycastHit hit)
    {
        int numbers = 0;
        if (hit.transform.position == lHand.transform.position || hit.transform.position == rHand.transform.position || hit.transform.position == lFoot.transform.position || hit.transform.position == rFoot.transform.position)
        {
            numbers += 1;
        }
        return numbers;
    }
}
