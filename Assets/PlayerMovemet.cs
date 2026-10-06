using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovemement : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 5, 0);
        }

        if (Input.GetKey("up"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 5);
        }

        if (Input.GetKey("down"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -5);
        }


        if (Input.GetKey("right"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(5, 0, 0);
        }

        if (Input.GetKey("left"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(-5, 0, 0);
        }




    }
}
