using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceGameManager : MonoBehaviour
{
    public Toggle muteButton;
    public bool isToggled = true;
    public AudioSource backgroundAudio;
    public static SpaceGameManager gm = null;
    [SerializeField]
    private Slider gravityScroller;
    [SerializeField]
    private Slider massScroller;
    [SerializeField]
    private Text gravityText;
    [SerializeField]
    private Text massText;
    [SerializeField]
    private PlanetMover planet;

    void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }
    void Start()
    {
        backgroundAudio.Play();
    }
    public void setPlanet(PlanetMover planet)
    {
        this.planet = planet;
    }
    // Update is called once per frame
    void Update()
    {
        gravityScroller.value = planet.sgravity;
        massScroller.value = planet.smass;
        gravityText.text = ""+planet.sgravity;
        massText.text = "" + planet.smass;

        if (Input.GetKeyDown(KeyCode.M))
        {
            toggleMusic();
            changeToggle();
            muteButton.isOn = !isToggled;
        }

    }

    public void AdjustMass()
    {
        planet.smass = massScroller.value;
    }
    public void AdjustGravity()
    {

        planet.sgravity = gravityScroller.value;
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void changeToggle()
    {
        isToggled = !isToggled;
    }
    public void toggleMusic()
    {
        if (isToggled)
        {
            backgroundAudio.Pause();
        }
        else
            backgroundAudio.Play();
    }
    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
