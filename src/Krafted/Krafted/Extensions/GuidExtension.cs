namespace System
{
    /// <summary>
    /// Provides extension methods to <see cref="Guid"/>.
    /// </summary>
    public static class GuidExtension
    {
        /// <summary>
        /// Checks whether this <see cref="Guid"/> is a <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="input">The <see cref="Guid"/>.</param>
        /// <returns>
        ///   <c>true</c> if this <see cref="Guid"/> is a <see cref="Guid.Empty"/>; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(this Guid input) => input.Equals(Guid.Empty);
    }
}
