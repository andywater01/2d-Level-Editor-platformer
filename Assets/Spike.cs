using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Movement move;
    private GameObject player;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            move = player.GetComponent<Movement>();
            move.SetisDead(true);
        }
    }
}
