using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankParseData : MonoBehaviour
{
    JsonParseData jsonParseData = new JsonParseData();
    public static List<RankListData> rankListData;
    public static int lastCurrent = 0;
    private void Awake()
    {
        rankListData = jsonParseData.JsonParseContent();
        rankListData.Sort();
        print(rankListData);
        lastCurrent = jsonParseData.JsonparseLastTime();
    }
    
}
