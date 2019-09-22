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
        GameManager.Get().playerName = GameObject.Find("PlayerNameInputField").GetComponent<InputField>().text;
        SceneManager.LoadScene("GameScene");
    }
}
