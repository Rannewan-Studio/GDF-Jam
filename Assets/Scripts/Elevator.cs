using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private DangerousSitutation _dangerousSitutation;

    public void Open()
    {
        Debug.Log("Open");
        _dangerousSitutation.ChangeVignette(Color.black, 0.230f);
        _dangerousSitutation.ChangeChromaticAberration(0f, false);
    }

    public void Close()
    {
        Debug.Log("Close");
    }
}
