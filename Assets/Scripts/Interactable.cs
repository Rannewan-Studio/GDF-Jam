using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnPositiveInteract;
    public UnityEvent OnNegativeInteract;
    public string InteractType = "Solo";
    public Hint Hint;
    public string LastInteractState = "Negative";
}
