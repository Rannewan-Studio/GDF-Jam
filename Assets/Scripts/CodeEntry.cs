using UnityEngine;
using UnityEngine.UI;

public class CodeEntry : MonoBehaviour
{
    [SerializeField] private GameObject _codeEntryPanel;
    [SerializeField] private Elevator _elevator;
    [SerializeField] private ElevatorCode _elevatorCode;
    [SerializeField] private Text _inputText;
    [SerializeField] private Text _informationText;

    public void Open()
    {
        _codeEntryPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EnterCode()
    {
        if(_inputText.text == _elevatorCode.Code)
        {
            Close();
            _elevator.Open();
        }
        else
        {
            _informationText.text = "Неправильный код";
        }
    }

    public void Close()
    {
        _codeEntryPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
