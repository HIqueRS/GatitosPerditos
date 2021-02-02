using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerCanvas : MonoBehaviour
{
    [SerializeField]
    private Image[] fish1;
    [SerializeField]
    private Image[] fish2;
    [SerializeField]
    private GameStatus status;

    public GameObject[] meows;

    public void AtualizeUI(int id)
    {
        status.fish[id]+=1;

        switch (id)
        {
            case 0: fish1[status.fish[id]-1].GetComponent<Image>().color = Color.white;
                break; 
            case 1: fish2[status.fish[id]-1].GetComponent<Image>().color = Color.white;
                break;   
        }
    }
}
