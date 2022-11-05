using Assets.Game.Scripts.GameObjects;
using UnityEngine;

/// <summary>
/// Helden Spezifische Funktionen
/// </summary>
public class Hero : GameObjectController
{
    public QuestObjects QuestObj;
    public QuestPanel Panel;

    [SerializeField]
    private string heroName = HeroService.Instance.HeroName;
    [SerializeField]
    private float health = HeroService.Instance.Health;
    [SerializeField]
    private int insanity = HeroService.Instance.Insanity;
    private int defence = HeroService.Instance.Defence;
    private int attack = HeroService.Instance.Attack;
    private int attackSpeed = HeroService.Instance.AttackSpeed;
    private int defaultDice = HeroService.Instance.DefaultDice;
    private Vector3 pos = SaveGameData.Pos;

    // TODO Init() bekommt später der Scene-Controller
    private async void Start()
    {
        await HeroService.Instance.Init();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        Panel.SetQuestWindowActive();
        QuestObj.SwitchStatusQuestObjects();
    }


    public string GetHeroName()
    {
        if (heroName != string.Empty)
        {
            Debug.Log("Player found");
        }
        return heroName;
    }


    public float GetHealth()
    {
        return health;
    }


    public int GetInsanity()
    {
        return insanity;
    }

}
