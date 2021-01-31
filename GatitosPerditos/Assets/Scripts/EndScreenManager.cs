using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{

    [SerializeField]
    private GameObject mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        CoolDown(3);
    }

    private IEnumerator CoolDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        mainMenuButton.SetActive(true);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
