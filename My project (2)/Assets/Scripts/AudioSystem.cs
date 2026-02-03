using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem Instance { get; private set; }

    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameController.Instance.ScoreChanged += PlayScoreSound;
        GameController.Instance.Jumped += PlayJumpSound;
        GameController.Instance.Died += PlayDeathSound;
    }

    private void PlayScoreSound(int score)
    {
        audioSource.PlayOneShot(scoreSound);
    }

    private void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    private void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
