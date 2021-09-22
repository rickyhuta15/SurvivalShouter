using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScrenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
     public void mulaiGame()
    {
        SceneManager.LoadScene(1);
    }
    public void keluarGame()
    {
        Application.Quit();
    }

    public void restartGame()
    {
         SceneManager.LoadScene(1);
         
    }
    public void restartGame1()
    {
         SceneManager.LoadScene(2);
         
    }
    public void nextLevel()
    {
         SceneManager.LoadScene(2);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
