using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLevelManager : MonoBehaviour
{

    SpriteRenderer sprite;

    [System.Serializable]

    //Класс описания уровней 
    public class TurretLevel {

        [SerializeField]
        private Sprite sprite;
        [SerializeField]
        private int cost;
        [SerializeField]
        private float range;
        [SerializeField]
        private float attackSpeed;
        [SerializeField]
        private int damage;
        [SerializeField]
        private float special;
        [SerializeField]
        private GameObject bullet;
        
        public GameObject Bullet {
            get {
                return bullet;
            }
        }

        public Sprite Sprite {
            get {
                return sprite;
            }
        }

        public int Cost
        {
            get
            {
                return cost;
            }
        }

        public float Range {
            get {
                return range;
            }
        }

        public float AttackSpeed {
            get {
                return attackSpeed;
            }
        }
        
        public int Damage {
            get {
                return damage;
            }
        }

        public float Special {
            get {
                return special;
            }
        }

    }

    [SerializeField] private TurretLevel[] Levels;
    public TurretLevel[] TurretLevels {
        get {
            return Levels;
        }
    }

    [SerializeField]
    private int currentLevelIndex = 0;

    PlayerResources resources;

    private int CurrentLevelIndex {
        set {
            currentLevelIndex = value;
            CurrentTurretLevel = Levels[value];
            sprite.sprite = CurrentTurretLevel.Sprite;
        }
        get {
            return currentLevelIndex;
        }
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        CurrentTurretLevel = Levels[currentLevelIndex];
        sprite.sprite = CurrentTurretLevel.Sprite;
        resources = PlayerResources.GetInstance();
    }

    public TurretLevel CurrentTurretLevel { private set; get; } 

    public void Promote() {
        if (CurrentLevelIndex + 1 != Levels.Length)
        {
            int cost = Levels[CurrentLevelIndex + 1].Cost - CurrentTurretLevel.Cost;
            if (resources.Money >= cost)
            {
                CurrentLevelIndex += 1;
                resources.Money -= cost;
            }
        }
    }

    public void Demote() {
        if (CurrentLevelIndex != 0)
        {
            int cost = CurrentTurretLevel.Cost - Levels[CurrentLevelIndex - 1].Cost;
            CurrentLevelIndex -= 1;
            resources.Money += cost / 2;
        }
        else {
            resources.Money += CurrentTurretLevel.Cost / 2;
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Levels[CurrentLevelIndex].Range);
    }

}
