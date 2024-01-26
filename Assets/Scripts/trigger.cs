using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public AudioClip triggerSound; // Assign your sound clip in the Unity Editor
    private AudioSource audioSource;

    void Start()
    {
        // Get or add an AudioSource component to the object this script is attached to
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = triggerSound;
    }

    void Update()
    {
        // You can add any additional update logic here if needed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.increaseScore();
            GameManager.instance.updateScore();

            PlayTriggerSound();
        }
    }

    void PlayTriggerSound()
    {
        if (audioSource != null && triggerSound != null)
        {
            audioSource.PlayOneShot(triggerSound);
        }
    }
}