using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float gravityAcceleration;
    private Rigidbody rb;

    public float launchPower;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0.0f, 0.0f, launchPower), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0.0f, 0.0f, -gravityAcceleration), ForceMode.Acceleration);
    }
}