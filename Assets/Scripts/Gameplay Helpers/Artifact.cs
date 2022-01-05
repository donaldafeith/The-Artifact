using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public int health;
    public int maxHealth = 150;
    public int bleed = 2;
    private AudioSource audioSource;
    private float bleedTimer;
    private PlayerBackPack playerBackPack;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
        bleedTimer = Time.time + 1f;
        playerBackPack = GameObject.FindWithTag("Player").GetComponent<PlayerBackPack>();

    }
    private void Update()
    {
        if (Time.time > bleedTimer)
        {
            health -= bleed;
            bleedTimer = Time.time + 1f;
        }
        CheckHealth();
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        CheckHealth();
    }
    void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            //Show GameOver UI
            GameOverUIController.instance.GameOver("You Lose!");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //  if (collision.GetComponent<PlayerBackPack>().currentNumberOfStoredFruits != 0)
            //  {
            //     audioSource.Play();
            //      health += collision.GetComponent<PlayerBackPack>().TakeFruits();
            //   }
            if (playerBackPack.currentNumberOfStoredFruits != 0)
            {
                audioSource.Play();
                health += playerBackPack.TakeFruits();
            }
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }
}
