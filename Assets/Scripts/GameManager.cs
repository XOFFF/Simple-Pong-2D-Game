using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int playerScore01 = 0;
    static int playerScore02 = 0;

    public GUISkin theSkin;

    Transform theBall;

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    public static void Score(string wallName)
    {
        if (wallName == "rightWall")
            playerScore01 += 1; 
        else if(wallName == "leftWall")
            playerScore02 += 1;

        //Debug.Log("Player Score 1 is " + playerScore01);
        //Debug.Log("Player Score 2 is " + playerScore02);
    }

    private void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2f - 150f-18f, 35f, 100f, 100f), "" + playerScore01);
        GUI.Label(new Rect(Screen.width / 2f + 150f-18f, 35f, 100f, 100f), "" + playerScore02);

        if (GUI.Button(new Rect(Screen.width / 2f - 121f / 2f, 35f, 121f, 53f), "RESET"))
        {
            playerScore01 = 0;
            playerScore02 = 0;

            theBall.gameObject.SendMessage("ResetBall");
        }
    }
}
