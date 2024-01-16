using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource FinishSound;

    private bool levelcomplete = false;
    private void Start()
    {
        FinishSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PLAYER1" && !levelcomplete)
        {
            FinishSound.Play();
            levelcomplete = true;   
            Invoke("completelvl", 2f);
            

        }
    }

    private void completelvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
