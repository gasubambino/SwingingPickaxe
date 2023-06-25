using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Ores")]
public class Ore : ScriptableObject
{
    public string oreName;
    public int oreDropAmount;
    public int oreHp;
    public Sprite oreSprite;
    public GameObject oreDrop;
}
