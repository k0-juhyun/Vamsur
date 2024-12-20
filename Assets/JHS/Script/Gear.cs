using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemdData.ItemType type;
    public float rate;

    public void Init(ItemdData data)
    {
        name = "Gear " + data.itemId;
        //transform.parent=GameManager.Instance.player.transform;
        transform.localPosition = Vector3.zero;

        type = data.itemtype;
        rate = data.damages[0];
        ApplyGear();
    }

    public void LevelUp(float rate)
    {
        this.rate = rate;
    }

    void ApplyGear()
    {
        switch (type)
        {
            case ItemdData.ItemType.Glove:
                RateUp();
                break;
            case ItemdData.ItemType.Shoes:
                SpeedUp();
                break;
        }
    }

    void RateUp()
    {
        /*Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();
        foreach (Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    weapon.speed = 150 + (150 * rate);
                    break;
                default:
                    weapon.speed = 0.5f + (1f - rate);
                    break;
            }
        }*/
    }

    void SpeedUp()
    {
        //float speed = 3;
        //GameManager.Instance.player.speed = speed + speed * rate;
    }
}
