using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private float side;

    void Start()
    {
        side = 10;
    }
    
    void Update()
    {
        Debug.Log( string.Concat(side,gameObject.name ));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        side = context.ReadValue<float>();
    }



}
