using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingPanel = null;

    private Level level;

    [SerializeField]
    Button beginnerButton = null;

    [SerializeField]
    Button eliteButton = null;

    [SerializeField]
    Button proButton = null;

    private void Start()
    {
        beginnerButton.onClick.AddListener(() => ClickAction(Level.Beginner));
        //eliteButton.onClick.AddListener(() => ClickAction(Level.Elite));
        //proButton.onClick.AddListener(() => ClickAction(Level.Pro));
    }

    public void ClickAction(Level level)
    {
        loadingPanel.SetActive(true);

        this.level = level;

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.sceneLoaded += GameStarted;
        SceneManager.LoadScene("MainScene");
    }

    private void GameStarted(Scene next, LoadSceneMode mode)
    {
        Town.Instance.townLevel = level;

        SceneManager.sceneLoaded -= GameStarted;
    }
}
