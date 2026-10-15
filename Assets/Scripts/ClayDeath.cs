using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClayDeath : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goblin Body")) // finds GameObjects With The "Goblin Body" Tag Refers To All Goblins Even If They Have Different Names
        {
            Die();
        }

    }
    void Die()

    {
        GetComponent<MeshRenderer>().enabled = false; // This Gets The Mesh Renderer Which Lets Us See The Shapes We Make I.e Clay, It Turns It Invisible Making Him "Dead"
        GetComponent<Rigidbody>().isKinematic = true; // This Stop Physics Acting On Clay Meaning He Can't Fall, Be Pushed Around Or Controlled By The Rigidbody Which Is Charge Of The Physics 
        GetComponent<ClayMovement>().enabled = false; // This Stops Clay From Being Able To Move, I.e Use Controls Because He Is "Dead"    
        Invoke(nameof(ReloadLevel), 1.3f); // This Sends Clay Back To The Start I.e Restarts The Level
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
