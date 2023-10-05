using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject Shooter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        other.rigidbody.velocity = Vector3.zero;
        other.transform.position = Shooter.transform.position + Vector3.forward;
        Debug.Log("Ball is dead");
    }
}
