using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public int i;
    public Rigidbody rb;
    public Transform transform;
    public Vector3 startPos;
    private AudioSource audio;
    private MeshRenderer mesh;
    public AudioSource falling;
    public Dropdown dropdown;
    public Material wood;
    public Material metal;
    public Material rubber;


    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        startPos = transform.position;
        audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 0)
        {
            audio.Play();
            falling.Stop();
        }
    }
    public void RandValueChange(int i)
    {
        switch (i)
        {
            case 0:
                mesh.material = wood;
                rb.mass = 5;
                break;
            case 1:
                mesh.material = metal;
                rb.mass = 40;
                break;
            case 2:
                mesh.material = rubber;
                rb.mass = 20;
                break;
        }
    }
        public void OnDropdownValueChange()
    {
        i = dropdown.value;
        switch (i)
        {
            case 0:
                mesh.material = wood;
                rb.mass = 5;
                break;
            case 1:
                mesh.material = metal;
                rb.mass = 40;
                break;
            case 2:
                mesh.material = rubber;
                rb.mass = 20;
                break;
        }


    }

}
