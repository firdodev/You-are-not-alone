using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCounterComponent : MonoBehaviour
{

    public int day = 0;

    [SerializeField] private double timeCheck = 0;
    [SerializeField] private double timeStep = 60*600;


    [SerializeField] private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCheck >= timeStep){
            day++;
            text.text = "Day " + day.ToString();
            timeCheck = 0;
        }
        timeCheck += 1;
    }
}
