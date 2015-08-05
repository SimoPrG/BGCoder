namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;

    public class Goblin : Creature
    {
        private const int GoblinAttack = 4;
        private const int GoblinDefense = 2;
        private const int GoblinHealthPoints = 5;
        private const decimal GoblinDamage = 1.5m;

        public Goblin()
            : base(GoblinAttack, GoblinDefense, GoblinHealthPoints, GoblinDamage)
        {
        }
    }
}
