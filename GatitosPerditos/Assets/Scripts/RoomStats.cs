﻿using System.Collections;
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

            other.transform.parent.GetChild(0).transform.position = new Vector3( camPos.position.x,camPos.position.y,-10);
        }
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovementTest>().position = id;

            collision.transform.parent.GetChild(0).transform.position = new Vector3(camPos.position.x, camPos.position.y, -10);
        }
    }
}
