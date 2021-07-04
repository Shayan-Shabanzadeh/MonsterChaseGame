using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameplayUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
   
}
