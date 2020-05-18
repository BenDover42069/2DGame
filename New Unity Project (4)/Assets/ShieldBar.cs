using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider shieldslider;
    // Start is called before the first frame update
    public void SetMaxShield(int Shield)
    {
        shieldslider.maxValue = Shield;

        shieldslider.value = Shield;

    }

    public void SetShield(int Shield)
    {
        shieldslider.value = Shield;
    }
}
