using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Elders.Cronus;

public abstract class EntityId<TAggregateRootId> : EntityId
    where TAggregateRootId : AggregateRootId
{
    protected EntityId() { }

    [Obsolete("Use the EntityId(ReadOnlySpan<char> idBase, TAggregateRootId rootId) constructor instead.")]
    public EntityId(string idBase, TAggregateRootId rootId, string entityName) : base(rootId, entityName, idBase) { }

    [Obsolete("Use the EntityId(ReadOnlySpan<char> idBase, TAggregateRootId rootId) constructor instead.")]
    public EntityId(ReadOnlySpan<char> idBase, TAggregateRootId rootId, ReadOnlySpan<char> entityName) : base(rootId, entityName, idBase) { }

    public EntityId(ReadOnlySpan<char> idBase, TAggregateRootId rootId)
    {
        if (idBase.IsEmpty) throw new ArgumentException("Entity base id cannot be empty", nameof(idBase));
        if (rootId is null) throw new ArgumentNullException(nameof(rootId));
        if (string.IsNullOrEmpty(Entity_name_but_not_really_because_the_tests_are_failing)) throw new InvalidOperationException($"{nameof(Entity_name_but_not_really_because_the_tests_are_failing)} cannot be null or empty.");

        Span<char> nss = stackalloc char[rootId.NSS.Length + 1 + Entity_name_but_not_really_because_the_tests_are_failing.Length + 1 + idBase.Length];
        rootId.NSS.CopyTo(nss[..rootId.NSS.Length]);
        nss[rootId.NSS.Length] = HIERARCHICAL_DELIMITER;
        Entity_name_but_not_really_because_the_tests_are_failing.CopyTo(nss[(rootId.NSS.Length + 1)..(rootId.NSS.Length + 1 + Entity_name_but_not_really_because_the_tests_are_failing.Length)]);
        nss[rootId.NSS.Length + 1 + Entity_name_but_not_really_because_the_tests_are_failing.Length] = PARTS_DELIMITER;
        idBase.CopyTo(nss[^idBase.Length..]);

        Span<char> urn = stackalloc char[5 + rootId.NID.Length + nss.Length];
        urn[0] = 'u'; urn[1] = 'r'; urn[2] = 'n'; urn[3] = PARTS_DELIMITER;
        rootId.NID.CopyTo(urn[4..(4 + rootId.NID.Length)]);
        urn[4 + rootId.NID.Length] = PARTS_DELIMITER;
        nss.CopyTo(urn[^nss.Length..]);

        if (IsUrn(urn) == false)
            throw new ArgumentException($"Invalid aggregate root id.");

        if (EntityRegex().IsMatch(nss) == false)
            throw new ArgumentException($"Invalid aggregate root id.");

        Span<byte> buffer = stackalloc byte[urn.Length];
        Encoding.UTF8.GetBytes(urn, buffer);
        RawId = buffer.ToArray();
    }

    TAggregateRootId aggregateRootId;

    public abstract string Entity_name_but_not_really_because_the_tests_are_failing { get; }

    [JsonIgnore]
    new public TAggregateRootId AggregateRootId
    {
        get
        {
            aggregateRootId = (TAggregateRootId)Activator.CreateInstance(typeof(TAggregateRootId), true);
            RawIdProperty.SetValue(aggregateRootId, base.AggregateRootId.RawId);

            return aggregateRootId;
        }
    }
}
