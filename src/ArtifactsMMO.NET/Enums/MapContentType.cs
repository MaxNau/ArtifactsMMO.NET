namespace ArtifactsMMO.NET.Enums
{
    /// <summary>
    /// Specifies the different types of content that can be present on a map.
    /// </summary>
    public enum MapContentType
    {
        /// <summary>
        /// A monster present on the map.
        /// </summary>
        Monster,

        /// <summary>
        /// A resource available for gathering on the map.
        /// </summary>
        Resource,

        /// <summary>
        /// A workshop where crafting can take place on the map.
        /// </summary>
        Workshop,

        /// <summary>
        /// A bank where players can store or withdraw items on the map.
        /// </summary>
        Bank,

        /// <summary>
        /// Grand Exchange, a marketplace for trading items on the map.
        /// </summary>
        GrandExchange,

        /// <summary>
        /// Tasks or quests that can be completed on the map.
        /// </summary>
        TasksMaster,

        /// <summary>
        /// Santa provide quest to the nice characters in this world.
        /// Seasonal content type
        /// </summary>
        SantaClaus,

        /// <summary>
        /// Different types of Npc's
        /// </summary>
        Npc,
    }
}
