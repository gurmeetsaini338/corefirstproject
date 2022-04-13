using System;

namespace corefirstproject.Models
{
    internal class RequiredAttribute : Attribute
    {
        public object ErrorMessage { get; set; }
    }
}