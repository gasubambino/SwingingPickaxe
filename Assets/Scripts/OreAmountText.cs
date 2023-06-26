using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OreAmountText : MonoBehaviour
{
    private TextMeshProUGUI text;

    [SerializeField] string oreDropName;
    string oreString;

    void Start()
    {  
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        switch (oreDropName)
        {
            case "gold":
                oreString = GameManager.Instance.playerGoldCount.ToString();
                break;
            case "pink":
                oreString = GameManager.Instance.playerPinkCount.ToString();
                break;
        }
        text.text = oreString;
    }
}
