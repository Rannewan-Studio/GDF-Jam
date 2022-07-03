using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DangerousSitutation : MonoBehaviour
{
    [SerializeField] private MentalHealth _playerMentalHealth;
    [SerializeField] private Color[] _vignetteColor;
    private PostProcessVolume _postProcessVolume;
    private ChromaticAberration _chromaticAberration;
    private Vignette _vignette;
    private bool _isDangerousSituation;

    private void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _chromaticAberration);
        _postProcessVolume.profile.TryGetSettings(out _vignette);
    }

    private void Update()
    {
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(_playerMentalHealth.Health <= 10)
        {
            ChangeVignette(_vignetteColor[0], 0.265f);
            ChangeChromaticAberration(1f, true);
        }
        else if(_playerMentalHealth.Health <= 20)
        {
            ChangeVignette(_vignetteColor[1], 0.260f);
            ChangeChromaticAberration(0.5f, true);
        }
        else if(_playerMentalHealth.Health <= 30)
        {
            ChangeVignette(_vignetteColor[2], 0.250f);
            ChangeChromaticAberration(0.4f, true);
        }
        else if(_playerMentalHealth.Health <= 40f)
        {
            _isDangerousSituation = true;
            ChangeVignette(_vignetteColor[3], 0.240f);
            ChangeChromaticAberration(0.2f, true);
        }
        else if(_playerMentalHealth.Health <= 50f)
        {
            _isDangerousSituation = true;
            ChangeVignette(Color.black, 0.230f);
            ChangeChromaticAberration(0.2f, true);
        }
    }

    public void ChangeVignette(Color color, float intensityValue)
    {
        _vignette.intensity.value = intensityValue;
        _vignette.color.value = color;
    }

    public void ChangeChromaticAberration(float intensityValue, bool state)
    {
        _chromaticAberration.intensity.value = intensityValue;
        _chromaticAberration.active = state;
    }
}
