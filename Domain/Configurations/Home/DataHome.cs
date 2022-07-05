using Domain.Configurations.General;

namespace Domain.Configurations.Home
{
    public class DataHome
    {
        public Settings? Settings { get; set; }
        public HighLight? HighLight { get; set; }
        public TimeLine? TimeLine { get; set; }
        public LastestNews? LastestNews { get; set; }
        public Thread? Thread { get; set; }
        public Caring? Caring { get; set; }
        public DontForget? DontForget { get; set; }
        public List<NewsByZone>? ListNewsByZone { get; set; }
        public BoxVideo? BoxVideo { get; set; }
    }
}
