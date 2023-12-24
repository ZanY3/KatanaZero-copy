using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeChangeManager : MonoBehaviour
{
    public GameObject timeVisuals;
    public int charge;
    public TMP_Text chargeText;
    public bool isSlow;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        var endCharge = charge - 1;
        chargeText.text = "Time change times: " + endCharge;
        if(charge > 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                timeVisuals.SetActive(true);
                SlowMotion();
                charge -= 1;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                timeVisuals.SetActive(false);
                NormalTime();
            }

        }  
        if(charge >= 5)
        {
            chargeText.text = "Time change times: " + 4;
            charge = 5;
        }
        if(charge <= 0)
        {
            chargeText.text = "Time change times: " + 0;
            charge = 0;
            NormalTime();
            timeVisuals.SetActive(false);
        }

    }
    private void SlowMotion()
    {
        Time.timeScale = 0.4f;
    }
    private void NormalTime()
    {
        Time.timeScale = 1f;
    }
}
