using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    public interface IHero
    {


        string Name { get; }


        int Experience { get; }


        IWeapon Weapon { get; }


        void Attack(ITarget target);


    }
}
