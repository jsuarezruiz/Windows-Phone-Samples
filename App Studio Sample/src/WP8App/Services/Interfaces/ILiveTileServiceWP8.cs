
namespace DoWapp.Services.Interfaces
{
    public interface ILiveTileServiceWP8
    {
        string Title { get; set; }
        string BackTitle { get; set; }

        int Count { get; set; }

        string BackContent { get; set; }
        string WideBackContent { get; set; }

        string BackgroundImagePath { get; set; }
        string BackBackgroundImagePath { get; set; }
        string SmallBackgroundImagePath { get; set; }
        string WideBackgroundImagePath { get; set; }
        string WideBackBackgroundImagePath { get; set; }

        string Url { get; set; }

        bool TileExists(string NavSource);
        void CreateTile(string NavSource);
        void DeleteTile(string NavSource);
        void UpdateTile();
    }
}
