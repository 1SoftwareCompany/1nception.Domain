using System;
using System.Runtime.CompilerServices;

namespace One.Inception;

public static class MessageIds
{
    private static readonly ConditionalWeakTable<IMessage, string> ids = new();

    public static string Get(IMessage message) =>
        ids.TryGetValue(message, out var id) ? id : null;

    public static void Set(IMessage message, string id) =>
        ids.TryAdd(message, id);
}

public static class MessageIdsExtensions
{
    public static string GetMessageId(this IMessage message) => message.MessageId;

    public static string GetOrCreateMessageId(this IMessage message)
    {
        if (message.MessageId is not null)
            return message.MessageId;

        string theId = Guid.NewGuid().ToString();
        MessageIds.Set(message, theId);

        return theId;
    }
}
