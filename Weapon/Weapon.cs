using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWeaponPro;

namespace WeaponPro
{
    public class Weapon : IWeapon
    {
        public int Hit(string target)
        {
            return 500;
        }
    }
}
