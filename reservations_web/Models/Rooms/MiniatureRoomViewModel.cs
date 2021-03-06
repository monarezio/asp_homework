namespace reservations_web.Models.Rooms
{
    /// <summary>
    /// This view model is used as a miniature model.
    /// For example for room listing.
    /// </summary>
    public class MiniatureRoomViewModel
    {
        public int RoomId { get; }
        public string Title { get; }
        public string Description { get; }

        public string ShortenedDescription { get; }

        public MiniatureRoomViewModel(int roomId, string title, string description)
        {
            RoomId = roomId;
            Title = title;
            Description = description;
            ShortenedDescription = Description.Length > 200 ? $"{Description.Substring(0, 197)}..." : Description;
        }
        
        
        //Generated by IDE
        protected bool Equals(MiniatureRoomViewModel other)
        {
            return RoomId == other.RoomId && string.Equals(Title, other.Title) && string.Equals(Description, other.Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is MiniatureRoomViewModel other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = RoomId;
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(MiniatureRoomViewModel left, MiniatureRoomViewModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MiniatureRoomViewModel left, MiniatureRoomViewModel right)
        {
            return !Equals(left, right);
        }
    }
}