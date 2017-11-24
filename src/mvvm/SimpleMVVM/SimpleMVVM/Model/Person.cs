namespace SimpleMVVM.Model
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
    }
}