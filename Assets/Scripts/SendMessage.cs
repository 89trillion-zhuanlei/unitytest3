using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessage : MonoBehaviour
{
    [SerializeField] private RankMessage rankMessage;
    public void CreateMessagePanel(object[] obj)
    {
        rankMessage.gameObject.SetActive(true);
        rankMessage.ShowNameAndNum((string)obj[0],int.Parse(obj[1].ToString()));
    }
}
