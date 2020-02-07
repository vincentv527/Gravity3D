using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tension : MonoBehaviour
{
    [SerializeField]
    private Rigidbody massRB;
    private float gravity = 9.81f;
    public Text gravityText;
    public Text massText;
    public Text tensionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        massText.text = "Mass: " + Math.Round(massRB.mass,2);
        gravityText.text = "Gravity: " + Math.Round(gravity,2);
        tensionText.text = "Tension: " + Math.Round(getTension(),2);

    }
    public void changeGravity(float newGravity)
    {
        gravity = newGravity;
        Physics.gravity = new Vector3(0, -gravity, 0);
    }
    public void changeMass(float newMass)
    {
        massRB.mass = newMass;
    }
    public float getTension()
    {
        float tension = 0;
        tension = massRB.mass * gravity;
        return tension;
    }
    
}
