using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double initialArmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; set; }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == true)
            {
                SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
            else
            {
                SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = initialArmorThickness;
        }

        public override string ToString()
        {
            string messgeToAdd;
            if (SubmergeMode == true)
            {
                messgeToAdd = "ON";
            }
            else
            {
                messgeToAdd = "OFF";
            }
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {messgeToAdd}";
        }
    }
}
