using System;

namespace DomEx.Models
{
    public class Opponent
    {
        private Location myLocation;
        private Random random;

        public Opponent(Location location)
        {
            this.myLocation = location;
            random = new Random();

        }

        public void Move()
        {
            bool hidden = false;
            while (!hidden)
            {
                if (myLocation is IHasExteriorDoor)
                {
                    IHasExteriorDoor locationWithDoor = myLocation as IHasExteriorDoor;
                    if (random.Next(2) == 1)
                    {
                        myLocation = locationWithDoor.DoorLocation;
                    }
                    int rand = random.Next(myLocation.Exits.Length);
                    myLocation = myLocation.Exits[rand];
                    if (myLocation is iHidingPlace)
                    {
                        hidden = true;
                    }
                }
            }
        }

        public bool Check(Location locaion)
        {
            if (locaion != myLocation)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}