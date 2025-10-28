#nullable enable
using CORE.APP.Domain;

namespace APP.Domain
{
    public class FootballerClub : Entity
    {
        public int FootballerId { get; set; }
        public Footballer Footballer { get; set; }

        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
}


