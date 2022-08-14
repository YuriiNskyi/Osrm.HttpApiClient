using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    public readonly struct RequestOption
    {
        private RequestOption(
            string option,
            string value,
            bool hasValue = false)
        {
            Option = option;
            Value = value;
            HasValue = hasValue;
        }

        public readonly string Option;
        public readonly string Value;
        public readonly bool HasValue;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RequestOption Create(string option, string value)
            => new (option, value, true);

        public static readonly RequestOption Empty = new (string.Empty, string.Empty, false);

        public override string ToString()
            => HasValue ? $"{Option}={Value}" : string.Empty;
    }
}
