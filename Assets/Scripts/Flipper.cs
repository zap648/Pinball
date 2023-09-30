using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public bool b_LeftTrigger;
    public bool b_RightTrigger;
    [SerializeField] bool b_Active;
    public float flipLength; // in degrees
    public float hitStrength;
    [SerializeField] private AnimationCurve FlipUp;
    [SerializeField] private AnimationCurve FlipDown;

    [SerializeField] float yRotation;
    private float _timer;

    // Start is called before any Update (Fucking lies)
    void Start()
    {
        Debug.Log(transform.rotation.eulerAngles.y);
        yRotation = transform.rotation.eulerAngles.y;
        b_Active = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput() // Sjekkar om knappane vert trykt ned, eller sloppe upp
    {
        if (b_LeftTrigger)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                b_Active = true;
                _timer = 0;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                b_Active = false;
                _timer = 0;
            }
        }

        else if (b_RightTrigger)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                b_Active = true;
                _timer = 0;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                b_Active = false;
                _timer = 0;
            }
        }

        FlipperSwitch();
    }

    private void FlipperSwitch()
    {
        // Set Flipper Up
        _timer += Time.deltaTime;

        // Rotasjon logikk
        float angleRotation;
        if (b_Active) angleRotation = FlipUp.Evaluate(_timer);
        else angleRotation = FlipDown.Evaluate(_timer);
        Vector3 localRotation;
        if (b_LeftTrigger)
            localRotation = new Vector3(transform.rotation.x, yRotation + angleRotation * -flipLength, transform.rotation.z);
        else
            localRotation = new Vector3(transform.rotation.x, yRotation + angleRotation * flipLength, transform.rotation.z);
        transform.localEulerAngles = localRotation;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.LogWarning($"This object collided with {other.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (b_Active)
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, hitStrength), ForceMode.VelocityChange);
        Debug.LogWarning($"This object triggered with {other.gameObject.name}");
    }
}