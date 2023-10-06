using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBumper : MonoBehaviour
{
    public GameObject Scorer;
    public int scoreValue;
    public float bumpPower;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * bumpPower, ForceMode.VelocityChange);
        Scorer.GetComponent<Score>().AddScore(scoreValue);
        Debug.Log("fBump!");
    }
}
