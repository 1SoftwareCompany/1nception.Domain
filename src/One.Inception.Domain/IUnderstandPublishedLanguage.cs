using System.Collections.Generic;

namespace One.Inception;

public interface IUnderstandPublishedLanguage
{
    IEnumerable<IPublicEvent> UncommittedPublicEvents { get; }
}
