using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuAfterDelay : MonoBehaviour
{

    public float delayInSeconds;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMenu());
    }

    private IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Menu");
    }

}
