﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace One.Inception;

public static partial class UrnRegex
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public const string Pattern = @"\A(?i:urn:(?!urn:)(?<nid>[\w][\w-]{0,30}[\w]):(?<nss>(?:[-a-z0-9()+,.:=@;$_!*'&~\/]|%[0-9a-f]{2})+)(?:\?\+(?<rcomponent>.*?))?(?:\?=(?<qcomponent>.*?))?(?:#(?<fcomponent>.*?))?)\z";

    [GeneratedRegex(Pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.ExplicitCapture, 500)]
    internal static partial Regex UrnRegexMatcher();

    public class Group
    {
        private string groupName;

        public Group(string groupName)
        {
            if (string.IsNullOrEmpty(groupName)) throw new ArgumentException(nameof(groupName));

            this.groupName = groupName;
        }

        public static Group NID => new Group("nid");
        public static Group NSS => new Group("nss");
        public static Group R_Component => new Group("rcomponent");
        public static Group Q_Component => new Group("qcomponent");
        public static Group F_Component => new Group("fcomponent");

        public override string ToString()
        {
            return groupName;
        }

        public static Group Create(string value)
        {
            value = (value ?? string.Empty).ToLower();
            return value switch
            {
                "nid" => NID,
                "nss" => NSS,
                "rcomponent" => R_Component,
                "qcomponent" => Q_Component,
                "fcomponent" => F_Component,
                _ => throw new NotSupportedException($"The group {value} is not supported by {nameof(UrnRegex)}"),
            };
        }
    }

    public static bool Matches(Uri urn)
    {
        var match = UrnRegexMatcher().Match(urn.AbsoluteUri);

        return match.Success;
    }

    public static Match Match(string urn) => UrnRegexMatcher().Match(urn);

    public static bool Matches(string urn)
    {
        try
        {
            Match match = UrnRegexMatcher().Match(urn);
            if (match.Success == false)
                return false;

            var uri = new Uri(urn);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static bool Matches(ReadOnlySpan<char> urn)
    {
        return UrnRegexMatcher().IsMatch(urn);
    }

    public static string GetGroup(string urnString, Group group)
    {
        var urn = new Uri(urnString);
        return GetGroup(urn, group);
    }

    public static string GetGroup(Uri urn, Group group)
    {
        Match match = UrnRegexMatcher().Match(urn.AbsoluteUri);
        return match.Groups[group.ToString()].Value;
    }
}
