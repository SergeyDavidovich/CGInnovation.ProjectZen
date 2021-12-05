using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace CGInnovation.ProjectZen.Projects
{
    /// <summary>
    /// Inherited from FullAuditedAggregateRoot<Guid> which makes the entity soft delete 
    /// (that means when you delete it, it is not deleted in the database, but just marked as deleted) 
    /// with all the auditing properties.
    /// </summary>
    public class Project : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        private Project()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? TenantId { get; private set; }

        internal Project(Guid id, [NotNull] string name, string description)
            : base(id)
        {
            SetName(name);
            SetDescription(description);
        }
        private void SetName([NotNull] string name)
        {
            Name =
                Check.NotNullOrWhiteSpace(name, nameof(name), 
                maxLength: ProjectConsts.MaxNameLength);
        }
        private void SetDescription([NotNull] string name)
        {
            Description =
                Check.NotNullOrWhiteSpace(name, nameof(name),
                maxLength: ProjectConsts.MaxDescriptionLength);
        }


        internal Project ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }
        internal Project ChangeDescription([NotNull] string description)
        {
            SetDescription(description);
            return this;
        }
    }
}
