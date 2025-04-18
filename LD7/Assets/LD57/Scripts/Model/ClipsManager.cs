using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ClipsManager : MonoBehaviour
{
    [SerializeField] private GameObject _clipPrefab;
    [SerializeField] private float _changeSpeed;

    private MainScreenLevelScenario _levelScenario;
    private GameObject _currentClip;
    private GameObject _newClip;

    private bool _isChangingClips;

    public void Initialize(MainScreenLevelScenario levelScenario)
    {
        _changeSpeed = 7;

        _levelScenario = levelScenario;
        ClipChanger.ClipEnded += ChangeClip;

        _currentClip = Instantiate(_clipPrefab, new Vector3(0, 0, 0), transform.rotation);
        _currentClip.transform.Find("ClipBootStrap").GetComponent<ClipBootStrap>().Initialize(_levelScenario.GetNextClip());
    }

    public void ChangeClip()
    { 
        _newClip = Instantiate(_clipPrefab, new Vector3(0, -10, 0), transform.rotation);
        _isChangingClips = true;
    }

    private void Update()
    {
        if (!_isChangingClips) return;

        if (_newClip.transform.position.y < 0)
        {
            _newClip.transform.position += Vector3.up * Time.deltaTime * _changeSpeed;
            _currentClip.transform.position += Vector3.up * Time.deltaTime * _changeSpeed;
        }
        else
        {
            _isChangingClips = false;
            KeepChanging();
        }
    }

    private void KeepChanging()
    {
        _newClip.transform.position = Vector3.zero;

        Destroy(_currentClip.gameObject);

        _currentClip = _newClip;
        _currentClip.transform.Find("ClipBootStrap").GetComponent<ClipBootStrap>().Initialize(_levelScenario.GetNextClip());
    }
}
