using PotpotMotorShopPOS.Models;

namespace PotpotMotorShopPOS.Helpers
{
    public static class Session
    {
        public static UserModel CurrentUser { get; set; }

        public static int UserID => CurrentUser?.UserID ?? 0;
        public static string Username => CurrentUser?.Username ?? string.Empty;
        public static string Fullname => CurrentUser?.Fullname ?? string.Empty;
        public static string Role => CurrentUser?.Role ?? string.Empty;
        public static void Clear()
        {
            CurrentUser = null;
        }
    }
}