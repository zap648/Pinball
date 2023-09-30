using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float minPower;
    [SerializeField] float power;
    public float maxPower;

    [SerializeField] bool bPowerUp;
    [SerializeField] bool bPinballHere;

    [SerializeField] GameObject pinball;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            bPowerUp = true;

        if (Input.GetKeyUp(KeyCode.DownArrow))
            releasePower();

        if (bPowerUp && power < maxPower)
            power += Time.deltaTime*50;
    }

    void releasePower()
    {
        if (bPinballHere)
            pinball.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, power), ForceMode.VelocityChange);
        power = 0;
        bPowerUp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pinball")
        {
            pinball = other.GameObject();
            bPinballHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Pinball")
        {
            pinball = null;
            bPinballHere = false;
        }
    }
}
