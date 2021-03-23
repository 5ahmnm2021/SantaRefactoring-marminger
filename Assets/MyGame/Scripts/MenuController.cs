using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour{
    public void Play(){
        SceneManager.LoadScene("MainScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
