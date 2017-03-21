using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.UI;

public class PlayGameScript : MonoBehaviour {

    const string SAVE_NAME = "Tutorial";
    bool isSaving;
    bool isCloudDataLoaded = false;

    public Text text;
    private int score;

	// Use this for initialization
	void Start () {

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        OnClickLogIn();
    }

    public void OnClickLogIn() {
        Social.localUser.Authenticate(success => { });
    }

    public void OnClickLogOut() {
        PlayGamesPlatform.Instance.SignOut();
    }


    /// <summary>
    /// 업적 공개 / 해제
    /// </summary>
    public void OnClickRevealingUnlocking() {
        Social.ReportProgress(GPGSIds.achievement_test1, 100.0f, (bool success) => { });
    }

    /// <summary>
    /// 업적 증대
    /// </summary>
    public void OnClickIncrementing() {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_test1, 5, (bool success) => { });
    }
    public void OnClickIncrementing2()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_test2, 5, (bool success) => { });
    }
    public void OnClickIncrementing3()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_test3, 4, (bool success) => { });
    }
    public void OnClickIncrementing4()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_test4, 3, (bool success) => { });
    }
    public void OnClickIncrementing5()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_test5, 10, (bool success) => { });
    }


    /// <summary>
    /// 업적 UI On
    /// </summary>
    public void OnClickAchievementsUi() {
        Social.ShowAchievementsUI();
    }

    /// <summary>
    /// 점수
    /// </summary>
    public void OnClickScoreUp() {
        score++;
        text.text = "Score : " + score;
    }

    /// <summary>
    /// 리더보드에 점수 게시
    /// </summary>
    public void OnClickScore() {
        Social.ReportScore(score, GPGSIds.leaderboard_testrederboard, (bool success)=>{ });
    }

    /// <summary>
    /// 리더보드 Ui 표시
    /// </summary>
    public void OnClickLeaderboardUi() {
        Social.ShowLeaderboardUI();
    }

    #region Saved Games

 


    #endregion /Saved Games

}
