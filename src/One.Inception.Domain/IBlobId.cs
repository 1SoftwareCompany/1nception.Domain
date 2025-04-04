using System;

namespace One.Inception;

public interface IBlobId
{
    ReadOnlyMemory<byte> RawId { get; }
}
