namespace Fmi.Tests.Contracts
{
    /// <summary>
    /// Represents a Void type, since Void is not a valid type in C#
    /// </summary>
    public sealed class Unit
    {
        /// <summary>
        /// Default and only value of Unit type
        /// </summary>
        public static readonly Unit Value = new Unit();
    }
}
