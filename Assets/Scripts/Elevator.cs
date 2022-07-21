using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Elevator : MonoBehaviour
{
    [SerializeField] private DangerousSitutation _dangerousSitutation;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<PlayerInteractor>() != null)
        {
            Close();
        }
    }

    public void Open()
    {
        Debug.Log("Open");
        _dangerousSitutation.ChangeVignette(Color.black, 0.230f);
        _dangerousSitutation.ChangeChromaticAberration(0f, false);
        Invoke("NextLevel", 1f);
    }

    public void Close()
    {
        _animator.SetBool("isClose", true);
        AudioPlayer.Instance.PlayAudio(1);
        StartCoroutine(ElevatorStop());
    }

    private IEnumerator ElevatorStop()
    {   
        yield return new WaitForSeconds(8f);
        _dangerousSitutation.ChangeVignette(Color.black, 0.8f);
        _dangerousSitutation.ChangeChromaticAberration(0.1f, true);

        yield return new WaitForSeconds(.25f);
        _dangerousSitutation.ChangeVignette(Color.black, 0.230f);
        _dangerousSitutation.ChangeChromaticAberration(0.25f, true);

        yield return new WaitForSeconds(.25f);
        _dangerousSitutation.ChangeVignette(Color.black, 0.8f);

        yield return new WaitForSeconds(.25f);
        _dangerousSitutation.ChangeVignette(Color.black, 0.230f);
        _dangerousSitutation.ChangeChromaticAberration(0, false);

        Navigator.Instance.SetNavigateText("Что? Лифт сломался? Как не вовремя. Ох у меня же клаустрофобия... Меня охватывает паника... (Нажми на F чтобы сделать глубокий вздох и успокоиться)");
        FindObjectOfType<MentalHealth>().CanReduce = true;
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
