using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Elders.Cronus.DomainModeling
{
    [DataContract(Name = "08fe27ca-411e-45ce-94ce-5d64c45eae6c")]
    public class StringId : AggregateRootId
    {
        [DataMember(Order = 1)]
        public string Id { get; protected set; }

        protected StringId() { }

        public StringId(string idBase, string aggregateRootName) : base(aggregateRootName)
        {
            if (string.IsNullOrWhiteSpace(idBase)) throw new ArgumentException("Empty string value is not allowed.", nameof(idBase));
            Id = idBase;
            RawId = setRawId(Urn);
        }

        public StringId(StringId idBase, string aggregateRootName) : base(aggregateRootName)
        {
            if (!IsValid(idBase)) throw new ArgumentException("Empty string value is not allowed.", nameof(idBase));
            Id = idBase.Id;
            RawId = setRawId(Urn);
        }

        public static bool IsValid(StringId aggregateRootId)
        {
            return (!ReferenceEquals(null, aggregateRootId)) && string.IsNullOrWhiteSpace(aggregateRootId.Id) == false;
        }

        public override IUrn Urn { get { return new Urn(AggregateRootName + ":" + Id.ToString()); } }
    }

    [DataContract(Name = "b78e63f3-1443-4e82-ba4c-9b12883518b9")]
    public class StringTenantId : StringId
    {
        [DataMember(Order = 2)]
        public string Tenant { get; set; }

        protected StringTenantId() { }

        public StringTenantId(string idBase, string aggregateRootName, string tenant) : base(idBase, aggregateRootName)
        {
            if (string.IsNullOrEmpty(tenant)) throw new ArgumentException("tenant is required.", nameof(tenant));
            Tenant = tenant;
            RawId = setRawId(Urn);
        }

        public StringTenantId(StringTenantId idBase, string aggregateRootName) : base(idBase.Id, aggregateRootName)
        {
            if (!IsValid(idBase)) throw new ArgumentException("Invalid base.", nameof(idBase));
            Tenant = idBase.Tenant;
            RawId = setRawId(Urn);
        }

        public StringTenantId(IUrn urn)
        {
            if (ReferenceEquals(null, urn)) throw new ArgumentNullException(nameof(urn));

            var tenantUrn = new TenantUrn(urn);
            Tenant = tenantUrn.Tenant;
            AggregateRootName = tenantUrn.Parts[2].ToLowerInvariant();
            Id = string.Join(string.Empty, tenantUrn.Parts.Skip(3));
            RawId = setRawId(Urn);
        }

        public static bool IsValid(StringTenantId aggregateRootId)
        {
            return StringId.IsValid(aggregateRootId) && !string.IsNullOrEmpty(aggregateRootId.Tenant);
        }

        public override IUrn Urn { get { return new TenantUrn(Tenant, AggregateRootName + ":" + Id); } }
    }
}