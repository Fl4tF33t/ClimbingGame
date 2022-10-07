using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public MeshGenerator meshGenerator;
    public RouteCreator routeCreator;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI gameWonText;
    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] TextMeshProUGUI createRouteText;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject createRouteButton;
    [SerializeField] GameObject player;
    [SerializeField] GameObject lHand;
    [SerializeField] GameObject rHand;
    [SerializeField] GameObject lFoot;
    [SerializeField] GameObject rFoot;


    // Update is called once per frame
    void FixedUpdate()
    {
        CheckCanClimb();
       
        //Debug.Log(routeCreator.holds.Length);
    }

    

    public void StartButton()
    {
        meshGenerator.StartButton();
        startText.text = "Change wall";
        createRouteButton.SetActive(true);
    }

    public void RouteCreatorButton()
    {
        routeCreator.StartRouteCreation();
        startButton.SetActive(false);
        createRouteButton.SetActive(false);
        player.SetActive(true);
        player.transform.position += new Vector3(meshGenerator.xSize / 2, 0,0);
        lHand.SetActive(true);
        lHand.transform.position += new Vector3(meshGenerator.xSize / 2, 0, 0);
        rHand.SetActive(true);
        rHand.transform.position += new Vector3(meshGenerator.xSize / 2, 0, 0);
        lFoot.SetActive(true);
        lFoot.transform.position += new Vector3(meshGenerator.xSize / 2, 0, 0);
        rFoot.SetActive(true);
        rFoot.transform.position += new Vector3(meshGenerator.xSize / 2, 0, 0);
    }

    void CheckCanClimb()
    {
        float handsHorizontal = rHand.transform.position.x - lHand.transform.position.x;
        float feetHorizontal = rFoot.transform.position.x - lFoot.transform.position.x;
        float leftHandVertical1 = lHand.transform.position.y - lFoot.transform.position.y;
        float leftHandVertical2 = lHand.transform.position.y - rFoot.transform.position.y;
        float rightHandVertical1 = rHand.transform.position.y - lFoot.transform.position.y;
        float rightHandVertical2 = rHand.transform.position.y - rFoot.transform.position.y;
        if (handsHorizontal < -1 || feetHorizontal < -1 || leftHandVertical1 < 0 || leftHandVertical2 < 0 || rightHandVertical1 < 0 || rightHandVertical2 < 0)
        {
            print("dead");
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.enabled = true;

    }

    void GameWon()
    {
        gameWonText.enabled = true;
    }
}
