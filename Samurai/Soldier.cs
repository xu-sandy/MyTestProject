using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWeaponPro;
using WeaponPro;

namespace Samurai
{
    public class Soldier
    {
        private readonly IWeapon weapon;
        public Soldier(IWeapon iweapon)
        {
            this.weapon = iweapon;
        }
        public int Attack(string target)
        {
            return this.weapon.Hit(target);
        }
    }
}
