//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WeaponList : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject[] prefabs;

//    private List<List<GameObject>> pools;

//    void Awake()
//    {
//        pools = new List<List<GameObject>>();


//        for (int i = 0; i < prefabs.Length; i++)
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

//        return select;
//    }

//    //�巡�� �ּ� ctrl + K + C
//    //���ֱ� ctrl + K + U
//    //�Լ�ã��

//}

