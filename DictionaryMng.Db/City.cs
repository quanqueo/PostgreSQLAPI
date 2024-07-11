namespace PostgreSQL_API.DB
{
    public class City
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double? Area { get; set; }
    }
}