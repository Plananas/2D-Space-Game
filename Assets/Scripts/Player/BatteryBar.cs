using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxBattery(float battery)
    {
        slider.value = battery;
        fill.color = gradient.Evaluate(1f);
    }


    public void SetBattery(float battery)
    {
        slider.value = battery;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
