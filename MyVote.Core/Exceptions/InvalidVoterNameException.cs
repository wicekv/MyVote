using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVote.Core.Exceptions
{
    internal class InvalidVoterNameException : CustomException
    {
        public string Name { get; }

        public InvalidVoterNameException(string name) : base($"Name: '{name}' is invalid.")
        {
            Name = name;
        }
    }
}
