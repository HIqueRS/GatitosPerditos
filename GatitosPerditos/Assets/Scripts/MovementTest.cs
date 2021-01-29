using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    [SerializeField]
    private InputSchema control;
    private float dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = Input.GetAxis(control.axis);

        transform.position += new Vector3(dir * Time.deltaTime, 0,0);
    }

   
}
