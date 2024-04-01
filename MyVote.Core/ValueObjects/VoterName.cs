using MyVote.Core.Exceptions;

namespace MyVote.Core.ValueObjects
{
    public sealed record VoterName
    {
        public string Value { get; set; }

        public VoterName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
            {
                throw new InvalidCandidateNameException(value);
            }

            Value = value;
        }

        public static implicit operator VoterName(string value) => value is null ? null : new VoterName(value);

        public static implicit operator string(VoterName value) => value?.Value;

        public override string ToString() => Value;
    }
}
