using System;

namespace Streetwood.API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IgnoreValidationAttribute : Attribute
    {
    }
}
