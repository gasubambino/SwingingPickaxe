using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OreAmountText : MonoBehaviour
{
    private TextMeshProUGUI text;

    [SerializeField] int oreIndex;
    private string[] oreType = new string[2];

    

    void Start()
    {
        
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        oreType[0] = GameManager.Instance.playerGoldCount.ToString();
        oreType[1] = GameManager.Instance.playerPinkCount.ToString();
        print(oreType[0]);
        print(oreType[1]);
        text.text = oreType[oreIndex];
    }
}
