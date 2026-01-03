using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // تتبع الإنشاء والتعديل
        public string CreatedBy { get; set; } = "--";
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(2);
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        // حالة الكيان (نشط / مجمد / محذوف)
        public EntityState EntityState { get; private set; } = EntityState.Active;
        private string? EntityStateMessage { get; set; }

        public string? GetEntityStateMessage() => EntityStateMessage;

        public void MarkAsFrozen(string message)
        {
            EntityState = EntityState.Frozen;
            EntityStateMessage = message;
        }

        public void MarkAsActive()
        {
            EntityState = EntityState.Active;
            EntityStateMessage = null;
        }

        public void MarkAsDeleted(string message)
        {
            EntityState = EntityState.Deleted;
            EntityStateMessage = message;
        }
    }

}