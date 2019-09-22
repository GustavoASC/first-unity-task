using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerNameScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(" listener no canvasss");
        Button b = GameObject.Find("StartGameButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnValueChanged(string value) 
    {
        Debug.Log("Aqui");

    }
}
