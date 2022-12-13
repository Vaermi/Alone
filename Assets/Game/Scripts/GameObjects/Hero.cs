using Assets.Game.Scripts.GameObjects;
using UnityEngine;

public class Hero : GameObjectController
{
    public QuestObjects QuestObj;
    public QuestPanelController Panel;
    public SceneController SceneController;
    private SaveGameData saveGameData;

    [SerializeField]
    private string heroName;
    private string heroId = HeroService.Instance.HeroId;
    private string currentQuest = HeroService.Instance.CurrentQuest;
    [SerializeField]
    private float health;
    [SerializeField]
    private int insanity = HeroService.Instance.Insanity;
    private int defence = HeroService.Instance.Defence;
    private int attack = HeroService.Instance.Attack;
    private int attackSpeed = HeroService.Instance.AttackSpeed;
    private int defaultDice = HeroService.Instance.DefaultDice;
    private bool isHerosTurn = HeroService.Instance.IsHerosTurn;


    private async void Start()
    {
        await HeroService.Instance.Init();
        saveGameData = GameObject.Find("Main Camera").GetComponent<SaveGameData>();
        Debug.Log("Hero");
        heroName = HeroService.Instance.HeroName;
        health = HeroService.Instance.Health;

        DontDestroyOnLoad(gameObject);

        string[] positions = HeroService.Instance.Position.Split(' ');
        

        if (positions.Length is 3)
        {
            transform.position = new Vector3(float.Parse(positions[0]), float.Parse(positions[1]), 0);
        }
    }


    public string CurrentPlayerPosition()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        string curPos = $"{x} {y} {z}";
        return curPos;
    }


    public void UseHealPotion()
    {
        HeroService.Instance.UseHealPotion();
    }


    public void HeroAttack()
    {
        HeroService.Instance.HeroAttack();
    }


    public void RunFromFight()
    {
        int number = HeroService.Instance.RunFromFight();
        if(number >= 70)
        {
            SceneController.ExitFightScreen();
        }
    }


    public void SpriteRendererDisabled()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
    }

    public void SpriteRendererEnabled()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = true;
    }
}
