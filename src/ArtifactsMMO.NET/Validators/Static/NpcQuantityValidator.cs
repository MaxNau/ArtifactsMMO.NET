namespace ArtifactsMMO.NET.Validators.Static
{
    internal class NpcQuantityValidator
    {
        internal static bool IsValid(int quantity)
        {
            if (quantity <= 0)
            {
                return false;
            }
            else if (quantity > 100)
            {
                return false;
            }

            return true;
        }
    }
}
