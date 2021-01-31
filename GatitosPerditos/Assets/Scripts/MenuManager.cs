using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ButtonsPanel;

    [SerializeField]
    private GameObject ControlsPanel;

    [SerializeField]
    private GameObject CreditsPanel;

    [SerializeField]
    private GameObject LoadPanel;
    

    public void PlayButton()
    {
        LoadPanel.SetActive(true);

        StartCoroutine(LoadYourAsyncScene());
    }

    public void ControlsButton()
    {
        ControlsPanel.SetActive(true);
        ButtonsPanel.SetActive(false);
    }

    public void CreditsButton()
    {
        CreditsPanel.SetActive(true);
        ButtonsPanel.SetActive(false);
    }

    public void CloseCredits()
    {
        CreditsPanel.SetActive(false);
        ButtonsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        ControlsPanel.SetActive(false);
        ButtonsPanel.SetActive(true);
    }

    private IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
