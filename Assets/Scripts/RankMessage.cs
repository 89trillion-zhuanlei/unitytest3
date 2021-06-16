using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
public class RankMessage : MonoBehaviour
{
    [SerializeField] private Text userName;
    [SerializeField] private Text rankNum;
    [SerializeField] private Button closeBtn;

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
    /// 关闭弹窗
    /// </summary>
    private void CloseRankMessage()
    {
        transform.gameObject.SetActive(false);
    }
}
