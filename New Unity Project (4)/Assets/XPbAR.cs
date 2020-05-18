using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPbAR : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update

    public void SetMaxXP(int XP)
    {
        slider.maxValue = XP;

        slider.value = XP;

    }

    public void SetStamina(int XP)
    {
        slider.value = XP;
    }
}
