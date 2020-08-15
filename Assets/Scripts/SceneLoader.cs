using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingPanel = null;

    public void ClickAction(int stageSize)
    {
        loadingPanel.SetActive(true);

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.0f);
        
        SceneManager.LoadScene("MainScene");
    }
}
