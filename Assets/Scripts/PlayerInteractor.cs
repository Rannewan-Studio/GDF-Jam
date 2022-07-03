using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private float _maxRayDistance;
    private Interactable _interactable;
    private RaycastHit _hit;
    private Ray _ray;

    private void Update()
    {
        Ray();
        CheckRay();
    }

    private void Ray()
    {
        _ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void CheckRay()
    {
        if(Physics.Raycast(_ray, out _hit, _maxRayDistance, _interactableLayer))
        {
            if(_hit.collider.GetComponent<Interactable>() != null)
            {
                _interactable = _hit.collider.GetComponent<Interactable>();
                _interactable.Hint.Show();
                if(Input.GetMouseButton(0))
                {
                    if(_interactable.InteractType == "Solo")
                    {
                        _interactable.OnPositiveInteract.Invoke();
                    }
                    else if(_interactable.InteractType == "Duo")
                    {
                        if(_interactable.LastInteractState == "Negative")
                        {
                            _interactable.OnPositiveInteract.Invoke();
                            _interactable.LastInteractState = "Positive";
                        }
                        else if(_interactable.LastInteractState == "Positive")
                        {
                            _interactable.OnNegativeInteract.Invoke();
                            _interactable.LastInteractState = "Negative";
                        }
                    }
                }
            }
        }

        if(_hit.collider == null && _interactable != null)
        {
            _interactable.Hint.Hide();
        }
    }
}
