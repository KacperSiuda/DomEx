namespace DomEx.Models
{
    public class OutsideWithHidingPlaces : Outside, iHidingPlace
    {
        public OutsideWithHidingPlaces(string name, bool hot, string hidingPlaces) : base(name, hot)
        {
            this.hidingPlaceDescription = hidingPlaces;
        }

        public string hidingPlaceDescription { get; }

        public override string Description
        {
            get { return base.Description + "Ktoś może ukrywać się " + hidingPlaceDescription + " ."; } 
        }
    }
}