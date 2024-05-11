using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public void LoadProject1Scene()
    {
        //Navigates to the Project1Scene
        SceneManager.LoadScene("Project1Scene");
    }

    public void LoadProject2Scene()
    {
        //Navigates to the Project2Scene
        SceneManager.LoadScene("Project2Scene");
    }

    public void LoadLoginScene() 
    {
        //Navigates to the LoginScene
        SceneManager.LoadScene("LoginScene");
    }
    
}

