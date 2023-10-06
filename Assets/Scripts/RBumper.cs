using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBumper : MonoBehaviour
{
    public GameObject Scorer;
    public int scoreValue;
    public float bumpPower;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 500;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce((other.transform.position - transform.position) * bumpPower, ForceMode.VelocityChange);
        Scorer.GetComponent<Score>().AddScore(scoreValue);
        Debug.Log("rBump!");
    }
}
