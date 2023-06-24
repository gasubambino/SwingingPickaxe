using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Item1 : MonoBehaviour
{
    public int price = 50;
    public GameObject priceText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        priceText.GetComponent<TextMeshProUGUI>().text = price.ToString();
    }
}
