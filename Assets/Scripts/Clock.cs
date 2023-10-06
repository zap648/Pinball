using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textClock;
    private DateTime startTime;

    void Awake()
    {
        textClock = GetComponent<TMPro.TextMeshProUGUI>();
        startTime = DateTime.Now;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = DateTime.Now - startTime;
        string hour = LeadingZero(time.Hours);
        string minute = LeadingZero(time.Minutes);
        string second = LeadingZero(time.Seconds);

        textClock.text = $"Time: {hour}:{minute}:{second}";
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
