namespace Project.Domain.Entities
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public List<User> Users { get; set; } = new();

        public Role(string name)
        {
            Name = name;
        }
    }
}
