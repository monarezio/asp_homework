namespace reservations_web.Models.Room
{
    /// <summary>
    /// This view model is used as a miniature model.
    /// For example for room listing.
    /// </summary>
    public class MiniatureRoomViewModel
    {
        public string RoomId { get; }
        public string Title { get; }
        public string Description { get; }

        public string ShortenedDescription { get; }

        public MiniatureRoomViewModel(string roomId, string title, string description)
        {
            RoomId = roomId;
            Title = title;
            Description = description;
            ShortenedDescription = Description.Length > 200 ? $"{Description.Substring(0, 197)}..." : Description;
        }
    }
}