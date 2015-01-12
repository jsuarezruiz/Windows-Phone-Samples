namespace Ejemplo_Xbox_Music.Model
{
    public enum XboxMusicItemType
    {
        Artist,
        Album,
        Track
    }

    public class XboxMusicItem
    {
        public string Title { get; set; }       
        public string Image { get; set; }
        public string Link { get; set; }
        public XboxMusicItemType Type { get; set; }
    }
}
