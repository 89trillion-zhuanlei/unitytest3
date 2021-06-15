using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankPanel : MonoBehaviour
{
    public static RankPanel Instance;
    private int lastTime;

    [SerializeField] private Text lastTimeText;

    //Myself个人显示
    [SerializeField] private Text myselfRankNum;
    [SerializeField] private Text myselfName;
    [SerializeField] private Text myselfTrophyNum;
    [SerializeField] private Button closeRankPanelBtn;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private RankMessage rankMessage;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        lastTime = RankParseData.lastCurrent;
        StartCoroutine("CountDown");
        SetMySelfRankUI();
        closeRankPanelBtn.onClick.AddListener(ColseRankPanel);
    }

    private void ColseRankPanel()
    {
        startPanel.SetActive(true);
        transform.gameObject.SetActive(false);
    }
    /// <summary>
    /// RankPanel 协程控制界面倒计时功能
    /// </summary>
    /// <returns></returns>
    IEnumerator CountDown()
    {
        while (lastTime > 0)
        {
            UpdataTime(lastTime);
            yield return new WaitForSeconds(1f);
            lastTime--;
        }
    }

    /// <summary>
    /// 倒计时功能
    /// </summary>
    /// <param name="lastTime"></param>
    private void UpdataTime(int lastTime)
    {
        int day = lastTime / (24 * 60 * 60);
        TimeSpan time = TimeSpan.FromSeconds(lastTime);
        lastTimeText.text = time.Days + "d " + time.Hours + "h " + time.Minutes + "m " + time.Seconds + "s";
    }

    /// <summary>
    /// 设置Rank Panel界面的个人信息栏
    /// </summary>
    private void SetMySelfRankUI()
    {
        int index = 1;
        List<RankListData> rankListDatas = RankParseData.rankListData;
        foreach (var value in rankListDatas)
        {
            if (value.id == "3716954261")
            {
                myselfRankNum.text = index.ToString();
                myselfName.text = value.name;
                myselfTrophyNum.text = value.trophy.ToString();
                break;
            }
            index++;
        }
    }

    private RankMessage rm;
    /// <summary>
    /// 在RankPanel界面下实例化 弹窗，显示点击用户信息
    /// </summary>
    /// <param name="name"></param>
    /// <param name="num"></param>
    public void CreateMeaasgePanel(string name, int num)
    {
        if (rm == null)
        {
            rm = Instantiate(rankMessage, transform);
        }
        rm.ShowNameAndNum(name, num);
    }
}