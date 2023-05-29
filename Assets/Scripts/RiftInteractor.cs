using UnityEngine;

public class RiftInteractor : PlayerInventoryBehaviour
{
    [SerializeField] private Transform _marker;
    
    
    new void Awake() => base.Awake();
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inventory.CurrentMarker = _marker;
            _audioManager.PlayRiftFoundSound();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inventory.CurrentMarker = null;
        }
    }

}
