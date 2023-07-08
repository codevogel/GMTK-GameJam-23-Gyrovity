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

    public void WinGame()
    {
        winText.gameObject.SetActive(true);
    }

    public void LoseGame()
    {
        loseText.gameObject.SetActive(true);
        StartCoroutine(ResetGameWithDelay(resetTimerSeconds));
    }

    private static IEnumerator ResetGameWithDelay(float delayInSeconds)
    {
        yield return new WaitForSecondsRealtime(delayInSeconds);
        SceneManager.LoadScene(0);
    }
}
