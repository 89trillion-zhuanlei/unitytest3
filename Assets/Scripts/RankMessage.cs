using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
public class RankMessage : MonoBehaviour
{
    public static RankMessage Instance;
    [SerializeField] private Text userName;
    [SerializeField] private Text rankNum;
    [SerializeField] private Button closeBtn;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        closeBtn.onClick.AddListener(CloseRankMessage);
    }

    /// <summary>
    /// 填充弹窗信息
    /// </summary>
    /// <param name="name"></param>
    /// <param name="num"></param>
    public void ShowNameAndNum(string name ,int num)
    {
        userName.text = name;
        rankNum.text = num.ToString();
    }

    /// <summary>
    /// 销毁弹窗，下一次点击flag设置为false，防止出现重复点击事件
    /// </summary>
    private void CloseRankMessage()
    {
        Destroy(transform.gameObject);
    }
}
