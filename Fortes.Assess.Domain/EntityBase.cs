using System;

namespace Fortes.Assess.Domain
{
    public class EntityBase
    {
        public int Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public DateTime? LastChanged { get; set; }
    }
}
