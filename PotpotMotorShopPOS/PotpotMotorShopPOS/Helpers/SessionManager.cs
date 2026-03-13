using System;

namespace PotpotMotorShopPOS.Helpers
{
    /// <summary>
    /// Manages current logged-in user session information
    /// </summary>
    public static class SessionManager
    {
        // ✅ Store current user information
        public static int CurrentUserID { get; private set; }
        public static string CurrentUsername { get; private set; }
        public static string CurrentFullName { get; private set; }
        public static string CurrentRole { get; private set; }
        public static DateTime LoginTime { get; private set; }

        /// <summary>
        /// Initialize session when user logs in
        /// Call this from your Login form after successful authentication
        /// </summary>
        public static void SetCurrentUser(int userId, string username, string fullName, string role)
        {
            CurrentUserID = userId;
            CurrentUsername = username;
            CurrentFullName = fullName;
            CurrentRole = role;
            LoginTime = DateTime.Now;

            System.Diagnostics.Debug.WriteLine(
                $"[Session] User logged in: {username} ({role}) at {LoginTime:yyyy-MM-dd HH:mm:ss}");
        }

        /// <summary>
        /// Clear session when user logs out
        /// </summary>
        public static void ClearSession()
        {
            System.Diagnostics.Debug.WriteLine(
                $"[Session] User logged out: {CurrentUsername} at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

            CurrentUserID = 0;
            CurrentUsername = null;
            CurrentFullName = null;
            CurrentRole = null;
            LoginTime = DateTime.MinValue;
        }

        /// <summary>
        /// Check if user is logged in
        /// </summary>
        public static bool IsLoggedIn => CurrentUserID > 0 && !string.IsNullOrEmpty(CurrentUsername);

        /// <summary>
        /// Get display name for CreatedBy field (can be customized)
        /// Format: "Username (Role)" or just "Username"
        /// </summary>
        public static string GetCreatedByString()
        {
            if (!IsLoggedIn)
                return "Unknown";

            // Option 1: Username only
            // return CurrentUsername;

            // Option 2: Username with role
            return $"{CurrentUsername} ({CurrentRole})";

            // Option 3: Full name with role
            // return $"{CurrentFullName} ({CurrentRole})";
        }

        /// <summary>
        /// Check if current user has specific role
        /// </summary>
        public static bool IsAdmin => CurrentRole?.Equals("Admin", StringComparison.OrdinalIgnoreCase) ?? false;

        public static bool IsCashier => CurrentRole?.Equals("Cashier", StringComparison.OrdinalIgnoreCase) ?? false;

        public static bool IsStaff => CurrentRole?.Equals("Staff", StringComparison.OrdinalIgnoreCase) ?? false;

        /// <summary>
        /// Get session duration
        /// </summary>
        public static TimeSpan GetSessionDuration()
        {
            if (!IsLoggedIn) return TimeSpan.Zero;
            return DateTime.Now - LoginTime;
        }
    }
}