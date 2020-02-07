using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void goToFreeFall()
    {
        SceneManager.LoadScene("FreeFall");
    }
    public void goToSelectGame()
    {
        SceneManager.LoadScene("PickGame");
    }
    public void goToFreeFallQuestions()
    {
        SceneManager.LoadScene("FreeFallQuestions");
    }
    public void goToPlanetGravity()
    {
        SceneManager.LoadScene("PlanetGravity");
    }
    public void goToFrictionInstructions()
    {
        SceneManager.LoadScene("FrictionInstuctions");
    }
    public void goToFriction()
    {
        SceneManager.LoadScene("Friction");
    }
    public void goToFrictionQuestions()
    {
        SceneManager.LoadScene("FrictionQuestions");
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void goToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void goToFFInstructions()
    {
        SceneManager.LoadScene("FreeFallInstuctions");
    }
}
