using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar: MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update

    public void SetMaxStamina(int Stamina)
    {
        slider.maxValue = Stamina;

        slider.value = Stamina;

    }

    public void SetStamina(int Stamina)
    {
        slider.value = Stamina;
    }
}

