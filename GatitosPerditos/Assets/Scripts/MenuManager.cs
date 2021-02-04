using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField]
    private Button firstbt;
    [SerializeField]
    private Button backCredits;
    [SerializeField]
    private Button backControls;
    
    private void Start() {
        play = false;

        firstbt.Select();
    }

    private void Update() {

        if(play)
        {
            if(p1.IsMeowning() || p2.IsMeowning() || p1.IsJumping() || p2.IsJumping())
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
        backControls.Select();
    }

    public void CreditsButton()
    {
        CreditsPanel.SetActive(true);
        ButtonsPanel.SetActive(false);
        backCredits.Select();
    }

    public void CloseCredits()
    {
        CreditsPanel.SetActive(false);
        ButtonsPanel.SetActive(true);
        firstbt.Select();
    }

    public void CloseControls()
    {
        ControlsPanel.SetActive(false);
        ButtonsPanel.SetActive(true);
        firstbt.Select();
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
