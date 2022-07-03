using UnityEngine;
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
    }

    public void Close()
    {
        _animator.SetBool("isClose", true);
        AudioPlayer.Instance.PlayAudio(1);
        Invoke("AudioStop", 7f);
    }

    private IEnumerator ElevatorStop()
    {   
        yield return new WaitForSeconds(7f);
        _dangerousSitutation.ChangeVignette(Color.black, 0.8f);

        yield return new WaitForSeconds(.5f);
        _dangerousSitutation.ChangeVignette(Color.black, 0.230f);

        yield return new WaitForSeconds(.5f);
        _dangerousSitutation.ChangeVignette(Color.black, 0.8f);

        yield return new WaitForSeconds(.5f);
        _dangerousSitutation.ChangeVignette(Color.black, 0.230f);

        Navigator.Instance.SetNavigateText("Что? Лифт сломался? Как не вовремя. О нет моя клаустрофобия... Меня охватывает паника... (Нажми на F чтобы сделать глубокий вздох и успокоиться)");
        FindObjectOfType<MentalHealth>().CanReduce = true;
    }
}
