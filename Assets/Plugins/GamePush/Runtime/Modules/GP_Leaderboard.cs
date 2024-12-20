﻿using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace GamePush
{
    public class GP_Leaderboard : GP_Module
    {
        private void OnValidate() => SetModuleName(ModuleName.Leaderboard);

        public static event UnityAction<string, GP_Data> OnFetchSuccess;
        public static event UnityAction<string, GP_Data> OnFetchTopPlayers;
        public static event UnityAction<string, GP_Data> OnFetchAbovePlayers;
        public static event UnityAction<string, GP_Data> OnFetchBelowPlayers;
        public static event UnityAction<string, GP_Data> OnFetchPlayer;
        public static event UnityAction OnFetchError;

        public static event UnityAction<string, int> OnFetchPlayerRatingSuccess;
        public static event UnityAction OnFetchPlayerRatingError;

        public static event UnityAction OnLeaderboardOpen;
        public static event UnityAction OnLeaderboardClose;

        private string _leaderboardFetchTag;
        private string _leaderboardPlayerFetchTag;


        [DllImport("__Internal")]
        private static extern void GP_Leaderboard_Open(
                string orderBy = "score",
                // DESC | ASC
                string order = "DESC",
                int limit = 10,
                int showNearest = 5,
                // none | first | last
                string withMe = "none",
                // level,exp,rank
                string includeFields = "",
                // level,rank
                string displayFields = ""
              );
        public static void Open(string orderBy = "score", Order order = Order.DESC, int limit = 10, int showNearest = 5, WithMe withMe = WithMe.none, string includeFields = "", string displayFields = "")
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            GP_Leaderboard_Open(orderBy, order.ToString(), limit, showNearest, withMe.ToString(), includeFields, displayFields);
#else

            ConsoleLog("OPEN");
#endif
        }



        [DllImport("__Internal")]
        private static extern void GP_Leaderboard_Fetch(
            string tag = "",
            string orderBy = "score",
            // DESC | ASC
            string order = "DESC",
            int limit = 10,
            int showNearest = 5,
            // none | first | last
            string withMe = "none",
            // level,exp,rank
            string includeFields = ""
        );
        public static void Fetch(string tag = "", string orderBy = "score", Order order = Order.DESC, int limit = 10, int showNearest = 0, WithMe withMe = WithMe.none, string includeFields = "")
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            GP_Leaderboard_Fetch(tag, orderBy, order.ToString(), limit, showNearest, withMe.ToString(), includeFields);
#else

            ConsoleLog("FETCH");
#endif
        }



        [DllImport("__Internal")]
        private static extern void GP_Leaderboard_FetchPlayerRating(
            string tag = "",
            string orderBy = "score",
            // DESC | ASC
            string order = "DESC"
        );
        public static void FetchPlayerRating(string tag = "", string orderBy = "score", Order order = Order.DESC)
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            GP_Leaderboard_FetchPlayerRating(tag, orderBy, order.ToString());
#else

            ConsoleLog("FETCH PLAYER RATING");
#endif
        }


        private void CallLeaderboardOpen() => OnLeaderboardOpen?.Invoke();
        private void CallLeaderboardClose() => OnLeaderboardClose?.Invoke();


        private void CallLeaderboardFetch(string data) => OnFetchSuccess?.Invoke(_leaderboardFetchTag, new GP_Data(data));
        private void CallLeaderboardFetchTop(string data) => OnFetchTopPlayers?.Invoke(_leaderboardFetchTag, new GP_Data(data));
        private void CallLeaderboardFetchAbove(string data) => OnFetchAbovePlayers?.Invoke(_leaderboardFetchTag, new GP_Data(data));
        private void CallLeaderboardFetchBelow(string data) => OnFetchBelowPlayers?.Invoke(_leaderboardFetchTag, new GP_Data(data));
        private void CallLeaderboardFetchOnlyPlayer(string data) => OnFetchPlayer?.Invoke(_leaderboardFetchTag, new GP_Data(data));


        private void CallLeaderboardFetchTag(string lastTag) => _leaderboardFetchTag = lastTag;
        private void CallLeaderboardFetchError() => OnFetchError?.Invoke();


        private void CallLeaderboardFetchPlayerTag(string lastTag) => _leaderboardPlayerFetchTag = lastTag;

        private void CallLeaderboardFetchPlayerRating(int playerPosition) => OnFetchPlayerRatingSuccess?.Invoke(_leaderboardPlayerFetchTag, playerPosition);

        private void CallLeaderboardFetchPlayerError() => OnFetchPlayerRatingError?.Invoke();
    }

    public enum Order : byte
    {
        DESC,
        ASC
    }

    public enum WithMe : byte
    {
        none,
        first,
        last
    }
}
