using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    int tokens = 0; // This Is The Token Counter

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Token"))
        {
            Destroy(other.gameObject);
            tokens++;
            Debug.Log("Tokens:" + tokens);
        }

    }
}
