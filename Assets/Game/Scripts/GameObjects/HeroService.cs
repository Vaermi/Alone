using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.GameObjects
{
    public class HeroService
    {
        private string heroName;
        public string HeroName { get { return heroName; } set { heroName = value; } }

        private float pos;
        public float Pos { get { return pos; } set { pos = value; } }

        private HeroService() { }

        private static HeroService instance;

        public static HeroService Instance 
        { get 
            { 
                if (instance == null) instance = new HeroService();
                return instance; 
            } 
        }


    }
}
