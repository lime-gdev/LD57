using System.Collections;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _title;
    [SerializeField] private GameObject _creators;
    [Header("Settings")]
    [SerializeField] private float _transitionDelay = 1.5f;
    [SerializeField] private float _alphaDuration = 1.5f;
    [Header("Animation")]
    [SerializeField] private Animator _titleAnimator;
    [SerializeField] private Animator _creatorsAnimator;
    
    private void Awake()
    {
        _title.SetActive(false);
        _creators.SetActive(false);
        
        StartCoroutine(GameEnter());
    }

    /// <summary>
    /// Bass, Creators appears instantly, alpha disappear
    /// Bass, title appears instantly
    /// </summary>
    private IEnumerator GameEnter()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlaySound(AudioManager.ESounds.bass2);
        _creators.SetActive(true);
        yield return new WaitForSeconds(3f);
        _creatorsAnimator.SetBool("FadeOut", true);
        yield return new WaitForSeconds(_alphaDuration);
        AudioManager.Instance.PlaySound(AudioManager.ESounds.bass2);
        _title.SetActive(true);
        yield return new WaitForSeconds(3f);
        _titleAnimator.SetBool("FadeOut", true);

    }
}
