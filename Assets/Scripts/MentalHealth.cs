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

    private bool _canReduce = true;
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
        if(_canReduce == true)
        {
            Health -= _reduceHealthValue * Time.deltaTime;
            DisplayHealth();
        }
    }

    public void CalmDown()
    {
        Health = _maxHealth;
        if(_onceDisplayCode == false)
        {
            _onceDisplayCode = true;
            StartCoroutine(FindObjectOfType<ElevatorCode>().DisplayCode());
        }
    }

    private void DeepBreath()
    {
        if(Input.GetKey(KeyCode.F))
        {
            CalmDown();
        }
    }
}
