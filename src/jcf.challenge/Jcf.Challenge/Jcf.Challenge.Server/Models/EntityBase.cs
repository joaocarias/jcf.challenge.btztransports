using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Challenge.Server.Models
{
    public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public DateTime? RemovedAt { get; set; }

        public Guid? UserCreateId { get; set; }

        public User? UserCreate { get; set; }

        public void Remove()
        {
            RemovedAt = DateTime.UtcNow;
            IsActive = false;
        }

        public EntityBase(Guid? userCreateId = null)
        {
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UserCreateId = userCreateId;  
        }        
    }
}
