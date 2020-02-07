using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager: MonoBehaviour
{
    private bool isOn = false;
    public Toggle toggle;
    public Text text;
    private int score;
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.gm.getScore();
        text.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeToggle();
            playMusic();
        }
       
    }
   
    public void ChangeToggle()
    {
        toggle.isOn = !toggle.isOn;
    }
    public void playMusic()
    {
        if (toggle.isOn == false)
        {
            backgroundMusic.Play();
        }
        else if(toggle.isOn == true)
        {
            backgroundMusic.Pause();
        }
    }
    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
