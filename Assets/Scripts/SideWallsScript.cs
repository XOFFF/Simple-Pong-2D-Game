using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallsScript : MonoBehaviour
{
    AudioSource audioMusic;

    void Start()
    {
        audioMusic = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball") {
            string wallName = transform.name;
            audioMusic.Play();
            GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("ResetBall");
        }
    }
}
