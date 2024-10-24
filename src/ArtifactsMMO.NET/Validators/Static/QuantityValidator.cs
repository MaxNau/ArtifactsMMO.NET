namespace ArtifactsMMO.NET.Validators.Static
{
    internal static class QuantityValidator
    {
        internal static bool IsValid(int quantity)
        {
            if (quantity <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
