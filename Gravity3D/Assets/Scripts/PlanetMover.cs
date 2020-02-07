using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMover : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Rigidbody rb;
    private float gravity = 600;
    public float sgravity = 1f;
    public float smass = 1f;
    public static List<PlanetMover> Planets;

    private void Update()
    {
        if (smass > 2)
            transform.localScale = new Vector3(smass / 2, smass / 2, smass / 2);
        else if(smass == 2)
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        else
            transform.localScale = new Vector3(smass, smass, smass);
    }
    private void FixedUpdate()
    {
        
        foreach(PlanetMover planet in Planets)
        {
            if (planet != this)
                Attract(planet);
        }
    }
    private void OnEnable()
    {
        if (Planets == null)
            Planets = new List<PlanetMover>();

        Planets.Add(this);
    }
    private void OnDisable()
    {
        Planets.Remove(this);
    }
   
    void Attract(PlanetMover attractObj)
    {
        Rigidbody rbToAttract = attractObj.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = (gravity *sgravity*smass) * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
    
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        SpaceGameManager.gm.setPlanet(this);
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag()

    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

}
