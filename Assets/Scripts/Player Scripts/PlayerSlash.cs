using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    [SerializeField]
    private GameObject slashPrefab;
    [SerializeField]
    private float attackCooldown = 0.3f;
    private float attackTimer;
    private AudioSource audioSource;
    private Camera mainCamera;
    private Vector3 spawnPosition;
    public GameObject artifact;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)&&Time.time > attackTimer)
        {
            Slash();
            attackTimer = Time.time + attackCooldown;

        }
    }
    void Slash()
    {
        if (!artifact)
        {
            return;
        }
        spawnPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        audioSource.Play();
        spawnPosition.z = 0;
        Instantiate(slashPrefab, spawnPosition, Quaternion.identity);
    }
}
