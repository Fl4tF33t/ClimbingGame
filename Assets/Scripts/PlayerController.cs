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
    public int holds;

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
                if (ReachableToClimb(hit))
                {
                    if (HoldsCheck(hit)[0])
                    {
                        Debug.Log(HoldsCheck(hit)[0]);
                        lHand.transform.position = hit.transform.position + handOffset;
                        transform.position = CentrePoint();
                        hit.transform.GetComponent<Holds>().HoldInUse(); 
                    }
                }
            }
        }
    }

    bool[] HoldsCheck (RaycastHit hit)
    {
        int holdLevel = hit.transform.GetComponent<Holds>().holdLevel;
        bool[] holdCheck = new bool[4];
        holdCheck[0] = false;
        holdCheck[1] = false;
        holdCheck[2] = false;
        holdCheck[3] = false;
        if(holdLevel < 0)
        {
            holdCheck[0] = false;
            holdCheck[1] = false;
            holdCheck[2] = false;
            holdCheck[3] = false;
        }else if (holdLevel == 0)
        {
            holdCheck[0] = false;
            holdCheck[1] = false;
            holdCheck[2] = true;
            holdCheck[3] = true;
        }else if (holdLevel == 1)
        {
            holdCheck[0] = false;
            holdCheck[1] = false;
            holdCheck[2] = true;
            holdCheck[3] = true;
        }
        else if (holdLevel == 2)
        {
            holdCheck[0] = true;
            holdCheck[1] = true;
            holdCheck[2] = true;
            holdCheck[3] = true;
        }
        else if (holdLevel == 3)
        {
            holdCheck[0] = true;
            holdCheck[1] = true;
            holdCheck[2] = true;
            holdCheck[3] = true;
        }
        return holdCheck;
    }

    void MovingRightHand()
    {
        if (Input.GetMouseButtonDown(1))
        { 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (ReachableToClimb(hit))
                {
                    if (HoldsCheck(hit)[1])
                    {
                        rHand.transform.position = hit.transform.position + handOffset;
                        transform.position = CentrePoint();
                        hit.transform.GetComponent<Holds>().HoldInUse();
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
                if (ReachableToClimb(hit))
                {
                    if (HoldsCheck(hit)[2])
                    {
                        lFoot.transform.position = hit.transform.position + handOffset;
                        transform.position = CentrePoint();
                        hit.transform.GetComponent<Holds>().HoldInUse();
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
                if (ReachableToClimb(hit))
                {
                    if (HoldsCheck(hit)[3])
                    {
                        rFoot.transform.position = hit.transform.position + handOffset;
                        transform.position = CentrePoint();
                        hit.transform.GetComponent<Holds>().HoldInUse();
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

    bool ReachableToClimb(RaycastHit hit)
    {
        bool canClimb;
        if (transform.position.x - hit.transform.position.x < -armRange || transform.position.x - hit.transform.position.x > armRange)
        {
            canClimb = false;
        }
        if (transform.position.y - hit.transform.position.y < -armRange || transform.position.y - hit.transform.position.y > armRange)
        {
            canClimb = false;
        }
        else
        {
            canClimb = true;
        }
        return canClimb;
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
