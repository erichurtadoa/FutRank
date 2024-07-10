namespace FutRank.Dtos
{
    public class UserDetailsDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string DateSignUp { get; set; }
        public long FixtureTime { get; set; }
        public ClubDto? FavouriteClub { get; set; }
    }
}
