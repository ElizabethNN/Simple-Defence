using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveTurret : MonoBehaviour
{

    [SerializeField]
    Image image;
    [SerializeField]
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        UpdateData();
    }

    public void UpdateData() {
        TurretLevelManager.TurretLevel level = TurretBrush.GetInstance().ActiveBrush.GetComponent<TurretLevelManager>().TurretLevels[0];
        image.sprite = level.Sprite;
        text.text = level.Cost + "$";
    }
}
