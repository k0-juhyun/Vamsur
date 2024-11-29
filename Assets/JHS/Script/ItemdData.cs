using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Item", menuName ="Scriptable Object/ItemData")]
public class ItemdData : ScriptableObject
{
    public enum ItemType { Melee, Range, Glove, Shoes, Heal}

    [Header("# Main Info")]
    public ItemType itemtype;
    public int itemId;
    public string itemName;
    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;

    [Header("# Level Data")]
    public float baseDamage;
    public int baseCount;
    public float[] damages;
    public int[] counts;

    [Header("# Weapon")]
    public GameObject projectile;
}
