using System;

/// <summary>
/// This is the ENUM class for cuisine type
/// </summary>
namespace ContosoCrafts.WebSite.CuisineType
{
    /// <summary>
    /// Function declares the ENUMs for cuisine type
    /// </summary>
    public enum CuisineType
    {
        // EnumMember value is intened to convert the numerical ratings
        // in the JSON file to their respective ENUM. Still not working, bug logged
        Chinese = 1,
        Korean = 2,
        Japanese = 3,
        Indian = 4,
        Italian = 5,
        Mexican = 6,
        Greak = 7,
        Thai = 8,
        Spanish = 9,
        Mediterranean = 10,
        French = 11,
        Vietnamese = 12,
        Seafood = 13,
        Cafe = 14,
        Dessert = 15,
    }

    public static class EnumExtensions
    {
        /// <summary>
        /// This will convert the ENUM values to a String
        /// </summary>
        public static string convertToString(CuisineType cuisineType)
        {
            string str = Enum.GetName(cuisineType);
            str = str.ToLower();

            return str;
        }
    }
}