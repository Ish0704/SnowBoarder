using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem crasheffect;
    [SerializeField] AudioSource audioSource;
    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableMoves();
            crasheffect.Play();
            audioSource.Play();
            Invoke("ReloadScene", delay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
