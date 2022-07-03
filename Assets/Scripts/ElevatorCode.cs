using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElevatorCode : MonoBehaviour
{
    [SerializeField] private Text _codeText;
    [SerializeField] private float _displayCoolDown;
    [SerializeField] private GameObject _flashAnimatorObject;
    [SerializeField] private Animator _flashAnimator;
    [SerializeField] private int[] _code;
    public string Code;

    private void Start()
    {
        RandomCode();
    }

    private void RandomCode()
    {
        _code[0] = Random.Range(0, 9);
        _code[1] = Random.Range(0, 9);
        _code[2] = Random.Range(0, 9);
        _code[3] = Random.Range(0, 9);

        Code = _code[0].ToString() + _code[1].ToString() + _code[2].ToString() + _code[3].ToString();
    }

    public IEnumerator DisplayCode()
    {
        yield return new WaitForSeconds(5f);
        Flash();
        ShowCode(_code[0]);

        yield return new WaitForSeconds(_displayCoolDown);
        Flash();
        ShowCode(_code[1]);

        yield return new WaitForSeconds(_displayCoolDown);
        Flash();
        ShowCode(_code[2]);

        yield return new WaitForSeconds(_displayCoolDown);
        Flash();
        ShowCode(_code[3]);
    }

    private void Flash()
    {
        _flashAnimatorObject.SetActive(true);
        _flashAnimator.SetTrigger("flash");
    }

    private void ShowCode(int codeNumber)
    {
        _codeText.enabled = true;
        _codeText.text = "" + codeNumber;
        Invoke("HideCode", .25f);
    }

    private void HideCode()
    {
        _flashAnimatorObject.SetActive(false);
        _codeText.enabled = false;
    }
}
