namespace ArtifactsMMO.NET.Validators.Static
{
    internal static class ItemQuantityValidator
    {
        internal static bool IsValid (int quantity)
        {
            if (quantity != 1)
            {
                return false;
            }

            return true;
        }
    }
}
