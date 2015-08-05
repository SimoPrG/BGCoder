namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using WarMachines.Common;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private readonly ICollection<IMachine> machines;

        private string name;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validation.CheckArgumentForNullReference(value, "Name cannot be null.");
                this.name = value;
            }
        }
        
        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();

            var numberOfMachinesString = this.machines.Count == 0 ? "no" : this.machines.Count.ToString();
            var machineOrMachinesString = this.machines.Count == 1 ? "machine" : "machines";

            result.AppendLine(string.Format("{0} - {1} {2}", this.Name, numberOfMachinesString, machineOrMachinesString));

            foreach (var machine in this.machines.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name))
            {
                result.Append(machine.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
