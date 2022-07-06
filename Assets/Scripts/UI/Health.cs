using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Text text;
    [SerializeField]
    string DefaultString;


    //TODO: Refactor because they similar
    private void Start()
    {
        text = GetComponent<Text>();
        PlayerResources resources = PlayerResources.GetInstance();
        text.text = DefaultString + resources.Health;
        resources.OnHealthChanged.AddListener(OnHealthChanged);
    }

    private void OnHealthChanged(int value)
    {
        text.text = DefaultString + value;
    }
}
