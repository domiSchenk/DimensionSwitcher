using UnityEngine;

public class PlayerInventoryBehaviour : MonoBehaviour
{
    protected AudioManager _audioManager;
    protected IInventory _inventory;

    public void Awake(){
        var audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");
        _audioManager = audioManagerObject.GetComponent<AudioManager>();
        
        var inv = GameObject.FindGameObjectWithTag("Inventory");
        _inventory = inv.GetComponent<IInventory>();
    }
}
