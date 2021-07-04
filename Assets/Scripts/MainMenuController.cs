using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        string clickedObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        int selectedCharacter = int.Parse(clickedObj);
        GameManager.instance.CharIndex = selectedCharacter;
        SceneManager.LoadScene("GamePlay");
    }
}
