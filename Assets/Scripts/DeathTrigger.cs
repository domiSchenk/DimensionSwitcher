using UnityEngine;

public class DeathTrigger : MonoBehaviour
{

    private AudioManager _audioManager;

    
    void Awake()
    {
        var audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");
        _audioManager = audioManagerObject.GetComponent<AudioManager>();
    }


    void OnTriggerEnter2D(Collider2D player)
    {
        Debug.Log("Player died");
        //get player by tag
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        var playerParent = player.gameObject.transform.parent.gameObject;
        _audioManager.PlayDeathSound();
        Destroy(playerParent);
        LevelManager.instance.Respawn();
    }
}
