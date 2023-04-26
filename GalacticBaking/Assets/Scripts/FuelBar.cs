using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{

    public Slider fuelSlider;

    public void SetMaxFuel(float fuel)
    {
        fuelSlider.maxValue = fuel;
        fuelSlider.value = fuel;
    }

    public void SetFuel(float fuel)
    {
        fuelSlider.value = fuel;
    }
}
