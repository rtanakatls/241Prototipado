using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    
    public void ChangeLifeBar(float value, float maxValue)
    {
        lifeBar.fillAmount = value / maxValue;
    }
}
