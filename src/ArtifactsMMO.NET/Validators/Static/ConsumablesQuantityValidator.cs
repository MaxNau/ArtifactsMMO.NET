namespace ArtifactsMMO.NET.Validators.Static
{
    internal static class ConsumablesQuantityValidator
    {
        internal static bool IsValid(int quantity)
        {
            if (quantity < 1 || quantity > 100)
            {
                return false;
            }

            return true;
        }
    }
}
