using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Analytics
{
    public static void SendStartLevel()
    {
    //    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "level " + (SceneManager.GetActiveScene().buildIndex + 1));

        var parameters = new Dictionary<string, object>();
        parameters.Add("level_count", 1);
        AppMetrica.Instance.ReportEvent("level_start", parameters);
        AppMetrica.Instance.SendEventsBuffer();
    }

    public static void SendOpenRegion(string guid)
    {
        if (PlayerPrefs.HasKey($"OpenRegionOrRecycler {guid}"))
            return;

        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, $"OpenRegion Or Recycler {guid}");

        var parameters = new Dictionary<string, object>();
        parameters.Add("OpenRegion Or Recycler", guid);

        AppMetrica.Instance.ReportEvent("OpenRegion Or Recycler", parameters);
        AppMetrica.Instance.SendEventsBuffer();

        PlayerPrefs.SetInt($"OpenRegionOrRecycler {guid}", 1);
    }

    public static void SendFishingRegion(string guid)
    {
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, $"Sat Down To Fishing");

        var parameters = new Dictionary<string, object>();
        parameters.Add("UnlockRegion", guid);

        AppMetrica.Instance.ReportEvent("UnlockRegion", parameters);
        AppMetrica.Instance.SendEventsBuffer();
    }

    public static void SendDriveJetskiRegion()
    {
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, $"Drive jetski");

        var parameters = new Dictionary<string, object>();
        parameters.Add("Drive jetski", 1);

        AppMetrica.Instance.ReportEvent("Drive jetski", parameters);
        AppMetrica.Instance.SendEventsBuffer();
    }

    public static void SendFinishLevel(int level)
    {
        if (PlayerPrefs.HasKey($"GAMEOVER"))
            return;

        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, $"level {level} FINISHED NEED UPDATE!");

        var parameters = new Dictionary<string, object>();
        //parameters.Add("map_number", SceneManager.GetActiveScene().buildIndex+1);
        parameters.Add("level_count", level);
     
        AppMetrica.Instance.ReportEvent("level_finish", parameters);
        AppMetrica.Instance.SendEventsBuffer();

        PlayerPrefs.SetInt("GAMEOVER", 1);
    }
}
