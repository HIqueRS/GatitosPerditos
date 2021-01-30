using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStats : MonoBehaviour
{
   
    public Vector2 id;
    [SerializeField]
    private Transform camPos;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MovementTest>().position = id;

            other.transform.parent.GetChild(0).transform.position = camPos.position;
        }
    }
}
