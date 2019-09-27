using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Utility class to manage space rockets
public class SpaceRocketUtils
{

    public static void MoveRocketsUp()
    {
        GameObject[] rockets = GameObject.FindGameObjectsWithTag("Rocket");
        for (int i = 0; i < rockets.Length; i++)
        {
            SpriteRenderer rocket = rockets[i].GetComponent<SpriteRenderer>();
            rocket.transform.Translate(new Vector3(0, 2, 0) * Time.deltaTime);
        }
    }

}

