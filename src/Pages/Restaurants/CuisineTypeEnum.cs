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
        UNKNOWN = 0,
        CHINESE = 1,
        INDIAN = 2,
        GREEK = 3,
        MEDITERRANEAN = 4,
        KOREAN = 5,
        ITALIAN = 6,
        SEAFOOD = 7,
        THAI = 8,
        FRENCH = 9,
        CAFE = 10,
        JAPANESE = 11,
        MEXICAN = 12,
        SPANISH = 13,
        VIETNAMESE = 14,
        DESSERT = 15,
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