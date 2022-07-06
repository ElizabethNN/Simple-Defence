using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    Text text;
    [SerializeField]
    string DefaultString;

    private void Start()
    {

        text = GetComponent<Text>();
        PlayerResources resources = PlayerResources.GetInstance();
        text.text = DefaultString + resources.Money;
        resources.OnMoneyChanged.AddListener(onMoneyChanged);
    }

    private void onMoneyChanged(int value) {
        text.text = DefaultString + value;
    }
}
