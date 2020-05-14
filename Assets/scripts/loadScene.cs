using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadScene : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public void SceneLoader(int sceneindex)
    {
        StartCoroutine(AsynchronousLoad(sceneindex));
    }
    IEnumerator AsynchronousLoad(int sceneindex)
    {
        

        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneindex);
        loadingScreen.SetActive(true);


        while (!ao.isDone)
        {

            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";



            yield return null;
        }
    }

}

