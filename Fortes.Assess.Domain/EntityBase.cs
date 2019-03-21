namespace Fortes.Assess.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] LastModified { get; set; }
    }
}
