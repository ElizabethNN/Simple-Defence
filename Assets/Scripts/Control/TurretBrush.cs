using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

public class TurretBrush : MonoBehaviour
{

    public UnityEvent OnBrushChanged;

    [SerializeField]
    List<GameObject> Pallete;
    [SerializeField]
    Tilemap Tilemap;
    [SerializeField]
    List<TileBase> BuildableTiles;
    [SerializeField]
    AudioClip clip;
    public GameObject ActiveBrush { get; private set; }
    List<List<GameObject>> Turrets;

    static TurretBrush _instance;

    public static TurretBrush GetInstance() {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
        ActiveBrush = Pallete[0];
        Turrets = new List<List<GameObject>>();
        for (int i = 0; i < Tilemap.size.x; i++) {
            List<GameObject> t = new List<GameObject>();
            for (int j = 0; j < Tilemap.size.y; j++)
                t.Add(null);
            Turrets.Add(t);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            ActiveBrush = Pallete[0];
            OnBrushChanged.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveBrush = Pallete[1];
            OnBrushChanged.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveBrush = Pallete[2];
            OnBrushChanged.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Vector3 vc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TileBase tile = Tilemap.GetTile(Tilemap.WorldToCell(vc));
            if (BuildableTiles.Contains(tile)) {
                int x = Mathf.RoundToInt(vc.x);
                int y = Mathf.RoundToInt(vc.y);
                if (Turrets[x][-1 * y] == null)
                {
                    int cost = ActiveBrush.GetComponent<TurretLevelManager>().TurretLevels[0].Cost;
                    if (PlayerResources.GetInstance().Money >= cost)
                    {
                        Turrets[x][-1 * y] = Instantiate(ActiveBrush, new Vector3(x, y, -1), new Quaternion());
                        PlayerResources.GetInstance().Money -= cost;
                    }
                    else {
                        AudioSource.PlayClipAtPoint(clip, new Vector3(x, y, -1));
                    }
                }
                else
                {
                    Turrets[x][-1 * y].GetComponent<TurretLevelManager>().Promote();
                }
            }
        }
    }

    private void OnDestroy()
    {
        _instance = null;
    }
}
