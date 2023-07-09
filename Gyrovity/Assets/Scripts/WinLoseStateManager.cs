using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseStateManager : MonoBehaviour
{
    private TextMeshProUGUI _winText;
    private TextMeshProUGUI _loseText;

    public float resetTimerSeconds;

    private bool _lost;
    private bool _won;

    private const float TimeBeforeSceneLoadInSeconds = 3f;
    
    private Scene _thisScene;


    private void Awake()
    {
        _winText = GameObject.FindGameObjectWithTag("Win Text").GetComponent<TextMeshProUGUI>();
        _winText.gameObject.SetActive(false);
        _loseText = GameObject.FindGameObjectWithTag("Fail Text").GetComponent<TextMeshProUGUI>();
        _loseText.gameObject.SetActive(false);
        
        _thisScene = SceneManager.GetActiveScene();

    }

    public void WinGame()
    {
        if (_won) return;
        
        
        _winText.gameObject.SetActive(true);
        AudioManager.Instance.PlaySuccess();
        _won = true;
        StartCoroutine(LoadNextScene());
    }

    public void LoseGame()
    {
        if (_lost) return;
        
        _loseText.gameObject.SetActive(true);
        AudioManager.Instance.PlayFail();
        StartCoroutine(ResetGameWithDelay(resetTimerSeconds));
        _lost = true;
    }

    private IEnumerator ResetGameWithDelay(float delayInSeconds)
    {
        yield return new WaitForSecondsRealtime(delayInSeconds);
        SceneManager.LoadScene(_thisScene.name);
    }

    private static IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(TimeBeforeSceneLoadInSeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
