using UnityEngine;
using UnityEngine.UI;

public class Navigator : MonoBehaviour
{
    public static Navigator Instance;

    [SerializeField] private Text _navigateText;

    private void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    public void SetNavigateText(string text)
    {
        _navigateText.text = text;
    }
}
