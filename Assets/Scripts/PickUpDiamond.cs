using UnityEngine;

public class PickUpDiamond : MonoBehaviour
{

    [SerializeField] private int _diamond = 1;

    private bool _isColliding = false;


    // void Awake() => base.Awake();
    protected AudioManager _audioManager;
    protected IInventory _inventory;

    public void Awake(){
        var audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");
        _audioManager = audioManagerObject.GetComponent<AudioManager>();
        
        var inv = GameObject.FindGameObjectWithTag("Inventory");
        _inventory = inv.GetComponent<IInventory>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        if (other.gameObject.CompareTag("Player"))
        {
            if (_isColliding) return;
            _isColliding = true;

            Destroy(gameObject);
            _inventory.Diamond += _diamond;
            _audioManager.PlayCollectSound();

            // LevelManager.instance.AddDiamondCount();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.instance.AddDiamondCount();
        }
    }
}
