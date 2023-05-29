using UnityEngine;


public interface IInventory
{
    int Diamond { get; set; }
    bool HasRift { get; set; }

    Transform CurrentMarker { get; set; }
}
