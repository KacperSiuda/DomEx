using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomEx.Models;

namespace DomEx
{
    public partial class Form1 : Form
    {
        public Location currentLocation { get; set; }
        private RoomWithDoor livingRoom;
        private RoomWithDoor kitchen;
        private Room dinningRoom;
        private OutsideWithDoor frontYard;
        private OutsideWithDoor backYard;
        private Outside garden;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Salon", "antyczny dywan", "dębowe drzwi z mosiężną klamką");
            kitchen = new RoomWithDoor("Kuchnia", "złote sztuczce", "rozsuwane drzwi");
            dinningRoom = new Room("jadalnia", "dębowy stół");
            frontYard = new OutsideWithDoor("Podwórko przed domem", false);
            backYard = new OutsideWithDoor("Podwórko za domem", true);
            garden = new Outside("Ogród", false);

            dinningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { dinningRoom };
            kitchen.Exits = new Location[] { dinningRoom };
            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { backYard, frontYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;

            MoveToANewLocation(livingRoom);
        }

        private void MoveToANewLocation(Location location)
        {
            currentLocation = location;
            exitsBox.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exitsBox.Items.Add(currentLocation.Exits[i].Name);
            }
            exitsBox.SelectedIndex = 0;

            descriptionBox.Text = currentLocation.Description;

            if (currentLocation is IHasExteriorDoor)
            {
                goThroughtDoor.Visible = true;
            }
            else
            {
                goThroughtDoor.Visible = false;
            }
        }

        private void goHereButton_Click(object sender, EventArgs e)
        {

            MoveToANewLocation(currentLocation.Exits[exitsBox.SelectedIndex]);
        }

        private void goThroughtDoor_Click(object sender, EventArgs e)
        {
            if (currentLocation is IHasExteriorDoor)
            {
                IHasExteriorDoor newLocation = currentLocation as IHasExteriorDoor;
                MoveToANewLocation(newLocation.DoorLocation);

            }

        }
    }
}
