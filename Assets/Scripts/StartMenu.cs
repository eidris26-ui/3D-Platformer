using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // Allows us to Have Multiple Scenes I.e A Start Scene Then The Game Scene
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public void StartGame() // Makes It Accesible To Players Meaning They Can Use The Buttons
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
