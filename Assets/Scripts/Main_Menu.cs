using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Main_Menu : MonoBehaviour
{
    public Animator transition;
    public GameObject loadingScreen;
    public Slider loadingBar;
    

    public void PlayGame()
    {
        StartCoroutine(LoadLevel());
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start-Quit");
        yield return new WaitForSeconds(1);

        Canvas canvasMenu = gameObject.GetComponent<Canvas>();

        canvasMenu.gameObject.SetActive(false);

        loadingScreen.SetActive(true);


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingBar.value = progress;
            yield return null;
        }

        
    }
}
