using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject createWallButton;
    [SerializeField] GameObject createRouteButton;

    public GameObject player;

    [SerializeField] Text createWallButtonText;

    [SerializeField] MeshGenerator meshGenerator;
    [SerializeField] RouteCreator routeCreator;

    // Start is called before the first frame update
    public void StartGameButton()
    {
        startButton.SetActive(!startButton.activeSelf);
        pauseButton.SetActive(!pauseButton.activeSelf);
        createWallButton.SetActive(!createWallButton.activeSelf);
    }

    public void PauseGameButton()   
    {
        startButton.SetActive(!startButton.activeSelf);
        pauseButton.SetActive(!pauseButton.activeSelf);
        createWallButton.SetActive(!createWallButton.activeSelf);
    }

    public void SettingsGameButton()
    {

    }

    public void CreateGameWallButton()
    {
        meshGenerator.StartButton();
        createWallButtonText.text = "Different Wall";
        createRouteButton.SetActive(true);
    }

    public void CreateGameRouteButton()
    {
        routeCreator.StartRouteCreation();
        createWallButton.SetActive(!createWallButton.activeSelf);
        createRouteButton.SetActive(!createRouteButton.activeSelf);
        player.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
