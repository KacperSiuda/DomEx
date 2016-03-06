namespace DomEx.Models
{
    public class RoomWithHidingPlaces : Room, iHidingPlace
    {

        public RoomWithHidingPlaces(string name, string decoration, string hidingPlaces) : base(name, decoration)
        {
            this.hidingPlaceDescription = hidingPlaces;
        }

        public string hidingPlaceDescription { get; }

        public override string Description
        {
            get
            {
                return base.Description + "Ktoś może ukrywać się " + hidingPlaceDescription + " .";
            }
        }
    }
}