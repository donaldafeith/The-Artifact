using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
    [SerializeField]
    private float harvestTime = 0.4f;
    private PlayerMovement playerMovement;
    private PlayerBackPack backPack;
    private AudioSource audioSource;
    private Collider2D collidedBush;
    private BushFruits hitBush;
    private bool canHarvestFruits;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        backPack = GetComponent<PlayerBackPack>();
        audioSource = GetComponent<AudioSource>();

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            TryHarvestFruit();
        }
    }
    void TryHarvestFruit()
    {
        if (!canHarvestFruits)
        {
            return;
        }
        if (collidedBush != null)
        {
            hitBush = collidedBush.GetComponent<BushFruits>();
            if (hitBush.HasFruits())
            {
                audioSource.Play();
                playerMovement.HarvestStopMovement(harvestTime);
                backPack.AddFruits(hitBush.HarvestFruit());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            canHarvestFruits = true;
            collidedBush = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            canHarvestFruits = false;
            collidedBush = null;
        }
    }
}
