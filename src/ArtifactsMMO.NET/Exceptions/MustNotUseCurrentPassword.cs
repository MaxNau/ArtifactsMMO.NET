using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when new password is the same as current password.
    /// </summary>
    public class MustNotUseCurrentPassword : Exception
    {
        internal MustNotUseCurrentPassword()
            : base("New password must not be the same as current password.")
        { }
    }
}
