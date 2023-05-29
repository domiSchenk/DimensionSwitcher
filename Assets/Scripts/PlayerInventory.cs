using UnityEngine;

public class PlayerInventory : MonoBehaviour, IInventory
{
    [SerializeField] private int _diamond = 0;
    public int Diamond { get => _diamond; set => _diamond = value; }  
    
     [SerializeField] private bool _hasRift = false;
    public bool HasRift { get => _hasRift; set => _hasRift = value; }

    [SerializeField] private Transform _currentMarker;
    public Transform CurrentMarker { get => _currentMarker; set => _currentMarker = value; }
}
