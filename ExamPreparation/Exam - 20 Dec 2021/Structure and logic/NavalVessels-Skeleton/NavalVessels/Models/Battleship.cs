using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double initialArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }


        public override void RepairVessel()
        {
            this.ArmorThickness = initialArmorThickness;
        }

        public void ToggleSonarMode()
        {
            if(SonarMode == false)
            {
                this.SonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                this.SonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override string ToString()
        {
            string messgeToAdd;
            if(SonarMode == true)
            {
                messgeToAdd = "ON";
            }
            else
            {
                messgeToAdd = "OFF";
            }
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {messgeToAdd}";
        }
    }
}
