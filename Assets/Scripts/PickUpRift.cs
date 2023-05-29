using UnityEngine;

public class PickUpRift : PlayerInventoryBehaviour
{

    [SerializeField] private int _diamond = 1;

    new void Awake() => base.Awake();
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inventory.HasRift = true;
            _audioManager.PlayCollectSound();
            Destroy(gameObject);
        }
    }
}
