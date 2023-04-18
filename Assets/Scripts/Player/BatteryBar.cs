using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{

    public Slider slider;

    public void SetBattery(int battery)
    {
        slider.value = battery;
    }

}
