using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrictionManager : MonoBehaviour
{
    public Text score;
    public Material rubber;
    public Material metal;
    public Material ice;
    public PhysicMaterial rubberFriction;
    public PhysicMaterial metalFriction;
    public PhysicMaterial iceFriction;
    public BoxCollider groundFriction;
    public MeshRenderer groundMaterial;
    public Rigidbody carRb;
    public Transform car;
    private Vector3 startPosition;
    private float force = 0;
    private float gravity = 1;
    public InputField forceInput;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = car.position;
    }
    // Update is called once per frame
    void Update()
    {
        carRb.AddForce(Vector3.right * force);
        score.text = "Score: " + GameManager.gm.getScore();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "StopSign")
        {
            changeForce("0");
        }
    }
    public void changeForce(string newForce)
    {
        force = float.Parse(newForce);
    }
    
    public void ChangeGroundRubber()
    {
        groundMaterial.material = rubber;
        groundFriction.material = rubberFriction;
    }
    public void ChangeGroundMetal()
    {
        groundMaterial.material = metal;
        groundFriction.material = metalFriction;
    }
    public void ChangeGroundIce()
    {
        groundMaterial.material = ice;
        groundFriction.material = iceFriction;
    }
    public void ResetCar()
    {
        force = 0;
        car.position = startPosition;
        forceInput.text = "0";
    }
    public void changeGravity(string newForce)
    {
        gravity = float.Parse(newForce);
        Physics.gravity = new Vector3(0, -gravity);
    }
}
