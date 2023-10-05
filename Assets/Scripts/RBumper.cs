using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBumper : MonoBehaviour
{
    public float bumpPower;

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
        other.gameObject.GetComponent<Rigidbody>().AddForce((other.transform.position - transform.position) * bumpPower, ForceMode.VelocityChange);
        Debug.Log("rBump!");
    }
}
