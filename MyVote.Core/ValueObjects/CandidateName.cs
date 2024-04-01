using MyVote.Core.Exceptions;

namespace MyVote.Core.ValueObjects
{
    public sealed record CandidateName
    {
        public string Value { get; set; }

        public CandidateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
            {
                throw new InvalidCandidateNameException(value);
            }

            Value = value;
        }

        public static implicit operator CandidateName(string value) => value is null ? null : new CandidateName(value);

        public static implicit operator string(CandidateName value) => value?.Value;

        public override string ToString() => Value;
    }
}
