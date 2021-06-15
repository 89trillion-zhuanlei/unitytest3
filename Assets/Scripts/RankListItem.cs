using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RankListItem : MonoBehaviour
{
    [SerializeField] private Image rankImage;
    [SerializeField] private Text rankText;
    [SerializeField] private Text name;
    [SerializeField] private Text trophyNum;
    [SerializeField] private Image arenaBadge;//段位
    [SerializeField] private Button clickbtn;
    /// <summary>
    /// 接收广播消息
    /// </summary>
    /// <param name="idx"></param>
    void ScrollCellIndex (int idx)
    {
        RankListData rankListData = RankParseData.rankListData[idx];
        name.text = rankListData.name;
        trophyNum.text = rankListData.trophy.ToString();
        
        if (idx<3)
        {
            rankImage.sprite = Resources.Load<Sprite>("rank/rank_" + (idx + 1));
            rankImage.SetNativeSize();
            rankImage.gameObject.SetActive(true);
        }
        else
        {
            rankImage.gameObject.SetActive(false);
            rankText.text = (idx + 1).ToString();
            rankText.gameObject.SetActive(true);
        }
        arenaBadge.sprite = Resources.Load<Sprite>("arenaBadge/arenaBadge_" + (rankListData.trophy / 1000 + 1).ToString());
        //添加点击事件监听
        clickbtn.onClick.AddListener(new UnityEngine.Events.UnityAction(
            () => { ClickRankListBtn(rankListData.name, idx+1);}));
    }

    /// <summary>
    /// RankList列表，添加点击事件
    /// </summary>
    /// <param name="name"></param>
    /// <param name="rankNum"></param>
    private void ClickRankListBtn(string name,int rankNum)
    {
        print("RankNum"+rankNum);
        RankPanel.Instance.CreateMeaasgePanel(name,rankNum); //调用排行榜界面的创建弹窗信息功能
    }
}