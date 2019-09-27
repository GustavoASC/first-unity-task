using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoFormCameraScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //
        Button b = GameObject.Find("StartGameButton").GetComponent<Button>();
        b.enabled = false;
        b.onClick.AddListener(delegate () { StartGameScene(); });
        //
        InputField playerNameField = GameObject.Find("PlayerNameInputField").GetComponent<InputField>();
        playerNameField.onValueChanged.AddListener(delegate (string content) { UpdateStartGameButtonStatus(content); });

    }

    // Update is called once per frame
    void Update()
    {
        SpaceRocketUtils.MoveRocketsUp();
    }

    private void UpdateStartGameButtonStatus(string content)
    {
        Button b = GameObject.Find("StartGameButton").GetComponent<Button>();
        if (string.IsNullOrEmpty(content))
        {
            b.enabled = false;
        }
        else
        {
            b.enabled = true;
        }
    }

    private void StartGameScene()
    {
        ConfigurePlayerName();
        ConfigureDifficulty();
        SceneManager.LoadScene("GameScene");
    }

    private void ConfigurePlayerName()
    {
        GameManager.Get().playerName = GameObject.Find("PlayerNameInputField").GetComponent<InputField>().text;
    }

    private void ConfigureDifficulty()
    {
        GameManager manager = GameManager.Get();
        float difficulty = GameObject.Find("DifficultySlider").GetComponent<Slider>().value;
        switch (difficulty)
        {
            case 3:
                manager.lives = 6;
                manager.ballSpeed = 7;
                break;
            case 2:
                manager.lives = 6;
                manager.ballSpeed = 6;
                break;
            case 1:
                manager.lives = 10;
                manager.ballSpeed = 4;
                break;
            default:
                break;
        }
        Debug.Log("Lives: " + manager.lives);
    }

}
