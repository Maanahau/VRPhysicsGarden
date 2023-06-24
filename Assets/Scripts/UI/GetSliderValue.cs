using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetSliderValue : MonoBehaviour
{

    public GameObject sliderObject;
    private Slider sliderComponent;
    private TextMeshProUGUI textMeshComponent;
    // Start is called before the first frame update
    void Start()
    {
        textMeshComponent = gameObject.GetComponent<TextMeshProUGUI>();
        sliderComponent = sliderObject.GetComponent<Slider>();
    }

    public void updateText()
    {
        textMeshComponent.text = sliderComponent.value.ToString();
        textMeshComponent.text = System.Math.Round(sliderComponent.value, 1).ToString();
    }
    
}
