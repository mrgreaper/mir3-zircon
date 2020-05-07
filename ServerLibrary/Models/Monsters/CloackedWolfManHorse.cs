using System;
using System.Collections.Generic;
using System.Text;
using Library;
using Server.Envir;
using S = Library.Network.ServerPackets;

namespace Server.Models.Monsters
{
    public class CloackedWolfManHorse : MonsterObject
    {
        public CloackedWolfManHorse() //get A random direction
        {
            Direction = (MirDirection)SEnvir.Random.Next(3);
        }
        public override void Die() //this is what we will do on death
        {
            SpawnMinions(1, 0, Target); //call the internal spawn minion function
            base.Die(); //then do the standard die stuff?
        }
        public override bool SpawnMinion(MonsterObject mob) //here is where we call the spawn nonster code, taking in the flagged monser (and using the direction above (well overriding it)
        {
            return mob.Spawn(CurrentMap.Info, Functions.Move(CurrentLocation, Functions.ShiftDirection(Direction, 3)));
        }
    }
}
