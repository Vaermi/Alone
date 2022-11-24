using Assets.Game.Scripts.GameObjects;
using System.Threading.Tasks;
using UnityEngine;

public class Hero : GameObjectController
{
    public QuestObjects QuestObj;
    public QuestPanelController Panel;
    public SceneController SceneController;

    [SerializeField]
    private string heroName;
    private string heroId = HeroService.Instance.HeroId;
    private string currentQuest = HeroService.Instance.CurrentQuest;
    [SerializeField]
    private float health = HeroService.Instance.Health;
    [SerializeField]
    private int insanity = HeroService.Instance.Insanity;
    private int defence = HeroService.Instance.Defence;
    private int attack = HeroService.Instance.Attack;
    private int attackSpeed = HeroService.Instance.AttackSpeed;
    private int defaultDice = HeroService.Instance.DefaultDice;
    private Vector3 pos = SaveGameData.Pos;


    private async void Start()
    {
        await HeroService.Instance.Init();
        Debug.Log("Hero");
        heroName = HeroService.Instance.HeroName;
    }


    public string CurrentPlayerPosition()
    {
        float x = pos.x;
        float y = pos.y;
        float z = pos.z;
        string curPos = $"{x}{y}{z}";
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
}
