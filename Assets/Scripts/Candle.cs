using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{

    public bool CandleOn;

    [SerializeField] private int timeStep = 0;
    [SerializeField] private int timeCheck = 60 * 60;

    // Start is called before the first frame update
    void Start()
    {
        CandleOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeStep >= timeCheck){

            if(CandleOn){
                CandleOn = false;
                print("Candle is: "+ CandleOn);
                timeCheck = 60 * 10;
            }else{
                CandleOn = true;
                print("Candle is: " + CandleOn);
                timeCheck = 60 * 60;
            }

            timeStep = 0;
        }
        timeStep++;
    }
}
