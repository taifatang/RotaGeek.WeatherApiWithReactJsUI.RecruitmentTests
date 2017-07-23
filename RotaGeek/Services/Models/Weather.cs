using System.Runtime.Serialization;

namespace RotaGeek.Services.Models
{
    public class Weather
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    [DataContract]
    public class Current
    {
        [DataMember]
        public Condition Condition { get; set; }
        [DataMember(Name = "temp_c")]
        public string Celsius { get; set; }
        [DataMember(Name = "temp_F")]
        public string Fahrenheit { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
    }
}
