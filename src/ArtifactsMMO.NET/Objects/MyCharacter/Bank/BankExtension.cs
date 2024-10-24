using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.Bank
{
    /// <summary>
    /// Bank extension details
    /// </summary>
    public class BankExtension
    {
        internal BankExtension() { }

        [JsonConstructor]
        internal BankExtension(int price)
        {
            Price = price;
        }

        /// <summary>
        /// Price of the bank extension.
        /// </summary>
        public int Price { get; }
    }
}
