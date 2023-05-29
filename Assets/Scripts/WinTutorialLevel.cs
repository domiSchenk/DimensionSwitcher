using UnityEngine;

public class WinTutorialLevel : MonoBehaviour
{
    private AudioManager _audioManager;

    void Awake()
    {
        var audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");
        _audioManager = audioManagerObject.GetComponent<AudioManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audioManager.PlayWinSound();
        }
    }
}
