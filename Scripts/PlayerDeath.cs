using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathsoundEfx;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathsoundEfx.Play();

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        
    }

    private void RestartLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
