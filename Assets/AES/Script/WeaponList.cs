//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WeaponList : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject[] prefabs;

//    List<GameObject> pools;

//    void Awake()
//    {
//        pools = new List<GameObject>prefabs.Length;


//        for (int i = 0; i < pools.Length; i++)
//        {
//            pools[i] = new List<GameObject>();
//        }
//    }

//    public GameObject Get(int i)
//    {
//        GameObject select = null;
//        foreach (GameObject item in pools[i])
//        {
//            if (!item.activeSelf)
//            {
//                select = item;
//                select.SetActive(true);
//                break;
//            }
//        }

//        if (!select)
//        {
//            select = Instantiate(prefabs[i], transform);
//            pools[i].Add(select);
//        }
//    }

//    //드래그 주석 ctrl + K + C
//    //없애기 ctrl + K + U
//    //함수찾기

//}

