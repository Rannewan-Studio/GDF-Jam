using UnityEngine;
using UnityEngine.UI;

public class Navigator : MonoBehaviour
{
    public static Navigator Instance;

    [SerializeField] private Text _navigateText;

    public void SetNavigateText(string text)
    {
        _navigateText.text = text;
    }
}
