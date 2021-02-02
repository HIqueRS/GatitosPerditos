using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    private Image[,] fish;
    [SerializeField]
    private GameStatus status;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizeUI(int id)
    {
        status.fish[id]+=1;

        fish[id,status.fish[id]-1].GetComponent<Image>().color = Color.white;
    }
}
