using System;

namespace Fortes.Assess.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public DateTime? LastChanged { get; set; }
    }
}
