using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{

    public Slider slider;

    public void SetBattery(float battery)
    {
        slider.value = battery;
    }

}
