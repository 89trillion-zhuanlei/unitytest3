using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartPanel : MonoBehaviour
{
    [SerializeField] private GameObject RankPanel;

    public void ClickStartBtn()
    {
        RankPanel.SetActive(true);
        transform.gameObject.SetActive(false);
    }

}
