namespace EFCore.Domain
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SecretIdentity? Identity { get; set; }
        public List<Weapon>? Weapons { get; set; }
        public List<HeroBattle>? HeroesBattles { get; set; }
    }
}
