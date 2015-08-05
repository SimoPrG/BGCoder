namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;


    // TODO: Try to inherit from Behemoth but keep in mind that the Behemoth has defined only a constructor.
    public class AncientBehemoth : Creature
    {
        private const int AncientBehemothAttack = 19;
        private const int AncientBehemothDefense = 19;
        private const int AncientBehemothHealthPoints = 300;
        private const decimal AncientBehemothDamage = 40m;

        public AncientBehemoth()
            : base(AncientBehemothAttack, AncientBehemothDefense, AncientBehemothHealthPoints, AncientBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}
