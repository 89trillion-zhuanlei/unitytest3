using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
public class JsonParseData
{
    public int lastCurrent = 0;
    private JSONNode jsonNode;

    private JSONNode JsonParse()
    {
        StreamReader streamReader = new StreamReader(Application.dataPath + "/Resources/ranklist.json");
        string str = streamReader.ReadToEnd();
        JSONNode json = JSON.Parse(str);
        return json;
    }
    
    /// <summary>
    /// 解析Json数据
    /// </summary>
    /// <returns>返回list集合，泛型为RankListData</returns>
    public List<RankListData> JsonParseContent()
    {
        jsonNode = JsonParse();
        List<RankListData> rankListDatas = new List<RankListData>();
        for (int i = 0; i < jsonNode["list"].Count; i++)
        {
            var data = jsonNode["list"][i];
            RankListData rankListData = new RankListData(data["uid"],data["nickName"],data["trophy"]);
            rankListData.name = data["nickName"];
            rankListDatas.Add(rankListData);
        }

        return rankListDatas;
    }

    public int JsonparseLastTime()
    {
        jsonNode = JsonParse();
        lastCurrent = jsonNode["countDown"];
        return lastCurrent;
    }
}
/// <summary>
/// 排行榜列表信息数据
/// </summary>
public class RankListData:IComparable<RankListData>
{
    public string id;
    public string name;
    public int trophy;

    public RankListData(string id,string name,int trophy)
    {
        this.id = id;
        this.name = name;
        this.trophy = trophy;
    }


    public int CompareTo(RankListData other)
    {
        return other.trophy.CompareTo(this.trophy);
    }
}
