using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleDamage : Specialty
    {
        private const decimal DoubleDamageCoeficient = 2m;
        private int rounds;

        public DoubleDamage(int rounds)
        {
            this.Rounds = rounds;
        }

        private int Rounds
        {
            get { return this.rounds; }
            set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0 and lesser than or equal to 10.");
                    
                }

                this.rounds = value;
            }
        }

        // TODO: extract common validator method for ArgumentNullException
        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            return currentDamage * DoubleDamageCoeficient;
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return;
            }

            // TODO: check if attackerWithSpecialty.CurrentAttack needs to be modified.
            //attackerWithSpecialty.CurrentAttack *= DoubleDamageCoeficient;
            this.rounds--;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("({0})", this.rounds);
        }
    }
}
