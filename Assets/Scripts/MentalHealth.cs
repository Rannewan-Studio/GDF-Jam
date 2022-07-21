using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MentalHealth : MonoBehaviour
{
    [SerializeField] private GameObject _healthPanel;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _reduceHealthValue;
    public float Health;

    public bool CanReduce = false;
    private bool _onceDisplayCode;

    private void Start()
    {
        _healthSlider.maxValue = _maxHealth;
    }

    private void Update()
    {
        ReduceHealth();
        DeepBreath();

        if(Health <= 0)
        {
            SceneManager.LoadScene(0);
        }

        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void DisplayHealth()
    {
        if(_healthPanel.activeSelf == false)
        {
            _healthPanel.SetActive(true);
        }
        _healthSlider.value = Health;
    }

    private void ReduceHealth()
    {
        if(CanReduce == true)
        {
            Health -= _reduceHealthValue * Time.deltaTime;
            DisplayHealth();
        }
    }

    public void CalmDown()
    {
        if(_onceDisplayCode == false)
        {
            _onceDisplayCode = true;
            Health = _maxHealth;
            StartCoroutine(FindObjectOfType<ElevatorCode>().DisplayCode());
        }
    }

    private void DeepBreath()
    {
        if(Input.GetKey(KeyCode.F))
        {
            CalmDown();
            Navigator.Instance.SetNavigateText("Хорошо, я успокоился... Теперь чтобы запустить лифт надо ввести код, сейчас его части будут появляться у тебя на экране");
        }
    }
}
