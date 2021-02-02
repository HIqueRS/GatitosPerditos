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

    [SerializeField]
    private GameObject StoryPanel;
    
    [SerializeField]
    private InputSchema p1;
    [SerializeField]
    private InputSchema p2;

    private bool play;
    
    private void Start() {
        play = false;
    }

    private void Update() {

        if(play)
        {
            if(p1.IsMeowning() || p2.IsMeowning())
            {   
                play = false;
                StartCoroutine(LoadYourAsyncScene());
            }
        }
        
    }

    public void PlayButton()
    {
        StoryPanel.SetActive(true);

        play = true;

        StartCoroutine(WaitTime(15.0f));
        
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

    private IEnumerator WaitTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        StartCoroutine(LoadYourAsyncScene());
    }
}
