using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;



    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = new Vector3(Player.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
    }
}
