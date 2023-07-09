using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class WinLoseStateManager : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;

    public float resetTimerSeconds;

    private bool _lost;
    private bool _won;

    public void WinGame()
    {
        if (_won) return;
        
        
        winText.gameObject.SetActive(true);
        AudioManager.Instance.PlaySuccess();
        _won = true;
    }

    public void LoseGame()
    {
        if (_lost) return;
        
        loseText.gameObject.SetActive(true);
        AudioManager.Instance.PlayFail();
        StartCoroutine(ResetGameWithDelay(resetTimerSeconds));
        _lost = true;
    }

    private static IEnumerator ResetGameWithDelay(float delayInSeconds)
    {
        yield return new WaitForSecondsRealtime(delayInSeconds);
        SceneManager.LoadScene(0);
    }
}
