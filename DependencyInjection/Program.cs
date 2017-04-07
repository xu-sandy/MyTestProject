using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samurai;
using WeaponPro;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Write Target1----");
            var target1 = Console.ReadLine();
            Soldier soldier = new Soldier(new Weapon());
            Console.WriteLine("----" + target1 + ":was hited " + soldier.Attack(target1) + "----");
            Console.WriteLine("----Write Target2----");
            var target2 = Console.ReadLine();
            Soldier soldier2 = new Soldier(new Weapon1());
            Console.WriteLine("----" + target2 + ":was hited " + soldier2.Attack(target2) + "----");
            Console.ReadLine();
        }
    }
}
