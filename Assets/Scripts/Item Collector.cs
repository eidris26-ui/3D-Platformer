using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    int tokens = 0; // This Is The Token Counter

    [SerializeField] TMP_Text tokensText;
    [SerializeField] AudioSource CollectionSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Token"))
        {
            Destroy(other.gameObject);
            tokens++;
             tokensText.text = "Tokens:" + tokens;
            CollectionSound.Play();
        }

    }
}
