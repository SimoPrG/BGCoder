namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Text;

    using WarMachines.Common;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        private readonly IList<string> targets;
        private string name;
        private IPilot pilot;

        protected Machine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validation.CheckArgumentForNullReference(value, "Name cannot be null.");
                this.name = value;
            }
        }
        
        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                Validation.CheckArgumentForNullReference(value, "Pilot cannot be null.");
                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            get { return new List<string>(this.targets); }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            var targetsString = this.targets.Count == 0 ? "None" : string.Join(", ", this.targets);

            result.AppendLine(string.Format("- {0}", this.Name));
            result.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            result.AppendLine(string.Format(" *Targets: {0}", targetsString));

            return result.ToString();
        }
    }
}
