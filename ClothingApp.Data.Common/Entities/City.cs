namespace ClothingApp.Data.Common.Entities
{
    public class City : EntityBase<long>
    {
        public string Name { get; set; }

        public long RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}
