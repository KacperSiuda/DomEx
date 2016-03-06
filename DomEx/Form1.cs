using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomEx.Models;

namespace DomEx
{
    public partial class Form1 : Form
    {
        public Location currentLocation { get; set; }

        private int moves;

        private Opponent opponent;

        private RoomWithDoor livingRoom;
        private RoomWithDoor kitchen;
        private RoomWithHidingPlaces dinningRoom;
        private OutsideWithDoor frontYard;
        private OutsideWithDoor backYard;
        private OutsideWithHidingPlaces garden;
        private Room stairs;
        private RoomWithHidingPlaces corridor;
        private RoomWithHidingPlaces smallBedRoom;
        private RoomWithHidingPlaces secondBedRoom;
        private RoomWithHidingPlaces bathRoom;
        private OutsideWithHidingPlaces roadway;



        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            opponent = new Opponent(frontYard);
            ResetGame(false);
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Salon", "antyczny dywan", "dębowe drzwi z mosiężną klamką", "szafa ścienna");
            kitchen = new RoomWithDoor("Kuchnia", "złote sztuczce", "rozsuwane drzwi", "szafka");
            dinningRoom = new RoomWithHidingPlaces("Jadalnia", "dębowy stół", "drewniana szafa");
            frontYard = new OutsideWithDoor("Podwórko przed domem", false, "Drzwi wejściowe");
            backYard = new OutsideWithDoor("Podwórko za domem", true, "Tylne wejście");
            garden = new OutsideWithHidingPlaces("Ogród", false, "szopa");
            stairs = new Room("Schody", "drewniana poręcz");
            corridor = new RoomWithHidingPlaces("Korytarz", "obrazek z psem", "szafa ścienna");
            smallBedRoom = new RoomWithHidingPlaces("Mała sypialnia", "małe łóżko", "małe łóżko");
            secondBedRoom = new RoomWithHidingPlaces("Druga sypialnia", "duże łóżko", "duże łóżko");
            bathRoom = new RoomWithHidingPlaces("Łazienka", "umywalka i toaleta", "prysznic");
            roadway = new OutsideWithHidingPlaces("Droga dojazdowa", false, "garaż");


            dinningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { dinningRoom, stairs };
            kitchen.Exits = new Location[] { dinningRoom };
            frontYard.Exits = new Location[] { backYard, garden, roadway };
            backYard.Exits = new Location[] { frontYard, garden, roadway };
            garden.Exits = new Location[] { backYard, frontYard };
            stairs.Exits = new Location[] { livingRoom, corridor };
            corridor.Exits = new Location[] { smallBedRoom, secondBedRoom, bathRoom };
            smallBedRoom.Exits = new Location[] { corridor };
            secondBedRoom.Exits = new Location[] { corridor };
            bathRoom.Exits = new Location[] { corridor };
            roadway.Exits = new Location[] { frontYard, backYard };


            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;

            MoveToANewLocation(livingRoom);
        }

        private void MoveToANewLocation(Location location)
        {
            moves++;
            currentLocation = location;
            RedrawForm();
        }

        private void RedrawForm()
        {
            exitsBox.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exitsBox.Items.Add(currentLocation.Exits[i].Name);
            }
            exitsBox.SelectedIndex = 0;

            descriptionBox.Text = currentLocation.Description + "\r\n(ruch numer " + moves + ")";
            if (currentLocation is iHidingPlace)
            {
                iHidingPlace hidingPlace = currentLocation as iHidingPlace;
                checkButton.Text = "Sprawdź " + hidingPlace.hidingPlaceDescription;
                checkButton.Visible = true;
            }
            else
            {
                checkButton.Visible = false;
            }
            if (currentLocation is IHasExteriorDoor)
            {
                goThroughtDoor.Visible = true;
            }
            else
            {
                goThroughtDoor.Visible = false;
            }
        }

        private void ResetGame(bool displayMessage)
        {
            if (displayMessage)
            {
                MessageBox.Show("Odnalazłeś mnie w " + moves + "ruchach!");
                iHidingPlace foundLocation = currentLocation as iHidingPlace;
                descriptionBox.Text = "Znalazłeś przeciwnika w " + moves + " ruchach! Ukrywał się w " +
                                      foundLocation.hidingPlaceDescription + ".";
            }
            moves = 0;
            hiddeButton.Visible = true;
            goHereButton.Visible = false;
            checkButton.Visible = false;
            goThroughtDoor.Visible = false;
            exitsBox.Visible = false;
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

        private void checkButton_Click(object sender, EventArgs e)
        {
            moves++;
            if (opponent.Check(currentLocation))
            {
                ResetGame(true);
            }
            else
            {
                RedrawForm();
            }
        }

        private void hiddeButton_Click(object sender, EventArgs e)
        {
            hiddeButton.Visible = false;

            for (int i = 1; i <= 10; i++)
            {
                opponent.Move();
                descriptionBox.Text = i + "...";
                Application.DoEvents();
                System.Threading.Thread.Sleep(2);

            }
            descriptionBox.Text = "Gotów czy nie nadchodzę ....";
            Application.DoEvents();
            System.Threading.Thread.Sleep(5);

            goHereButton.Visible = true;
            exitsBox.Visible = true;
            MoveToANewLocation(livingRoom);
        }
    }
}
