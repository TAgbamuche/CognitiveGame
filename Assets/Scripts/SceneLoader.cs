/* 
    Author: Agbamuche Ewere
    Goal: Load each scene
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScene"); // Use the name of your home scene here
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene"); // Use the name of your home scene here
    }
    public void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene"); // Use the name of your home scene here
    }
    public void LoadLogScene()
    {
        SceneManager.LoadScene("LogScene"); // Use the name of your home scene here
    }
    public void LoadSettingScene()
    {
        SceneManager.LoadScene("SettingScene"); // Use the name of your home scene here
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}