namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    class Tank : Machine, ITank
    {
        private const double InitialTankHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialTankHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            DefenseMode = !DefenseMode;

            if (DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendLine(string.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF"));
            return result.ToString();
        }
    }
}
