using UnityEngine;

namespace Shinjingi
{
    [RequireComponent(typeof(Controller))]
    public class Rift : PlayerInventoryBehaviour
    {

        private Controller _controller;
        private GameObject _grassPlane, _mudPlane;
        private Grid _grassGrid, _mudGrid;

        private bool _desiredRift = false;

        new void Awake()
        {
            base.Awake();
            _controller = GetComponent<Controller>();
            _grassPlane = GameObject.FindGameObjectWithTag("GrassPlane");
            _mudPlane = GameObject.FindGameObjectWithTag("MudPlane");
            _grassGrid = _grassPlane.GetComponent<Grid>();
            _mudGrid = _mudPlane.GetComponent<Grid>();
        }

        void Update()
        {
            _desiredRift |= _controller.input.RetrieveInteractInput(this.gameObject);
        }

        void FixedUpdate()
        {
            Debug.Log(_desiredRift);
            if (_desiredRift && _inventory?.HasRift == true && _inventory?.CurrentMarker != null)
            {
                transform.position = _inventory.CurrentMarker.position;
                _audioManager.PlayRiftSound();
            }
            _desiredRift = false;
        }
    }
}
