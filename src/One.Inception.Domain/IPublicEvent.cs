﻿namespace One.Inception;

/// <summary>
/// An event which is part of the domain's Published Language
/// </summary>
public interface IPublicEvent : IMessage
{
    string Tenant { get; }
}
