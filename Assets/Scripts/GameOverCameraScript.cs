﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverCameraScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //
        Text status = GameObject.Find("Status").GetComponent<Text>();
        if (GameManager.Get().winner == true)
        {
            status.text = "Congrats!";
        }
        else
        {
            status.text = "Game Over";
        }
        //
        Text playerName = GameObject.Find("PlayerName").GetComponent<Text>();
        playerName.text = GameManager.Get().playerName;
        //
        Text playerScore = GameObject.Find("PlayerScore").GetComponent<Text>();
        playerScore.text = ScoreManager.Get().GetPoints() + "";
    }

    // Update is called once per frame
    void Update()
    {
        SpaceRocketUtils.MoveRocketsUp();
    }
}
