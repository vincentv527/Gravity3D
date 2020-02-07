using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrictionQuestionManager : MonoBehaviour
{
    public AudioSource correct;
    public AudioSource wrong;
    public Transform carPos;
    public MeshRenderer groundMat;
    public Rigidbody car;
    public Button leftAnswer;
    public Button rightAnswer;
    public Button resetButton;
    public BoxCollider ground;
    public PhysicMaterial[] physicsMats;
    public Material[] materials;
    public Text question;
    public Text ans1;
    public Text ans2;
    public Text carMass;
    public Text roadMaterial;
    public Text gravity;
    public Text score;
    public float delayTime = 3f;

    private float grav;
    private float mass;
    private PhysicMaterial currentMat;
    private float ans;
    private int answeredCorrect = 0;
    private Vector3 startPos;
    private int scoreDisplay;
    private bool move = false; 

    void Awake()
    {
        startPos = carPos.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        generateQuestion();
    }

    private void generateQuestion()
    {
        move = false;
        question.color = Color.white;
        question.text = "What is the minimum amount of force needed to move the car?";
        carPos.position = startPos;
        grav = UnityEngine.Random.Range(8, 21);
        mass = UnityEngine.Random.Range(5, 31);
        int rand = UnityEngine.Random.Range(0, 3);
        currentMat = physicsMats[rand];
        groundMat.material = materials[rand];
        ground.material = currentMat;

        carMass.text = mass.ToString();
        gravity.text = grav.ToString();
        roadMaterial.text = currentMat.name + " (" + currentMat.staticFriction + ")" ;

        ans = grav * mass * currentMat.staticFriction;

        int randButton = UnityEngine.Random.Range(1, 11);
        if(randButton % 2 == 0)
        {
            ans1.text = ans.ToString();
            ans2.text = (ans + randButton).ToString();
        }
        else
        {
            ans2.text = ans.ToString();
            ans1.text = (ans + randButton).ToString();
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftAnswer.onClick.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightAnswer.onClick.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            resetButton.onClick.Invoke();
        }
        scoreDisplay = GameManager.gm.getScore();
        score.text = "Score: " + scoreDisplay.ToString();
        if (move)
        {
            carPos.Translate(Vector3.forward * Time.deltaTime * 7);
        }
    }
    public void chooseAns1()
    {
        if(ans1.text == ans.ToString())
        {
            move = true;
            correct.Play();
            question.color = Color.green;
            question.text = "Correct!";
            GameManager.gm.incScore();
        }
        else
        {
            wrong.Play();
            question.text = "Sorry, please try again!";
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    public void chooseAns2()
    {
        if (ans2.text == ans.ToString())
        {
            move = true;
            correct.Play();
            question.color = Color.green;
            question.text = "Correct!";
            GameManager.gm.incScore();
        }
        else
        {
            wrong.Play();
            question.text = "Sorry, please try again!";
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    public void reset()
    {
        Start();
    }
    IEnumerator TransitionToNextQuestion()
    {
        yield return new WaitForSeconds(delayTime);
        if (answeredCorrect < 5)
            Start();
        else
            question.text = "Congrats! You completed this section!";
    }
}
