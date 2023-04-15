using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  Global Data
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
///     - You can use the public variables and methods
/// </summary>
public class ScGameGlobalData : MonoBehaviour {

    // //////////////////////////////////////////////
    // //////////////////////////////////////////////
    // //////////////////////////////////////////////
    // Game data

    public static float maxPlayersMovUnits = 30f;  // Maximun force to move PLAYERS
    public static float maxMinionsMovUnits = 20f;  // Maximun force to move MINIONS

    public static int maxGameTime_ms = 60 * 1000;  // Maximun Game time in milliseconds

    public static DateTime initialDate = DateTime.Now;  // Instant the game starts

    // //////////////////////////////////////////////
    // Game- score data

    public static int initialLives = 5; // Initial value of the number of lives of the players

    public int profitsPlayer_Near;  // Number of profits that the player Near get along the play
    public int profitsPlayer_Far;  // Number of profits that the player Far get along the play

    public int livesPlayer_Near;  // Number of lives remaining for player Near
    public int livesPlayer_Far;  // Number of lives remaining for player Far

    // //////////////////////////////////////////////
    // //////////////////////////////////////////////
    // //////////////////////////////////////////////
    // Game Space data

    public static float GS_scale_X = 10f;  // Scale of Game Space in x corrdinate (field width escale)
    public static float GS_scale_Z = 20f;  // Scale of Game Space in y corrdinate (field length escale)

    public static float GS_scale_Y = 1f;  // Scale of Game Space in y corrdinate (field height escale)


    // //////////////////////////////////////////////
    // //////////////////////////////////////////////
    // //////////////////////////////////////////////
    // Teams data

    public GameObject Team_Near;
    public static string idTeam_Near = "Near";
    public List<gameElement> listTeam_Near;
    public string player_near_mode = "User";  // "User" - "NPC" - "randon"
    private string group_near;

    public GameObject Team_Far;
    public static string idTeam_Far = "Far";
    public List<gameElement> listTeam_Far;
    public string player_far_mode = "randon";  // "User" - "NPC" - "randon"
    private string group_far;

    // /////////
    public static Vector3 Team_Near_init_position = new Vector3(0, (5f / 2f) * ScGameGlobalData.GS_scale_Y, (-10f / 4F) * ScGameGlobalData.GS_scale_Z);
    public static Vector3 Team_Far_init_position = new Vector3(0, (5f / 2f) * ScGameGlobalData.GS_scale_Y, (10f / 4F) * ScGameGlobalData.GS_scale_Z);

    public static float playerScale_all = 5;
    public static Vector3 PlayerScale = new Vector3(playerScale_all, playerScale_all, playerScale_all);
    public static float minionScale_all = 5;
    public static Vector3 MinionScale = new Vector3(minionScale_all, minionScale_all, minionScale_all);

    public static int numOfMinions = 10;

    // //////////////////////////////////////////////
    // //////////////////////////////////////////////
    // //////////////////////////////////////////////
    // Profits data

    public List<gameElement> listProfits;  // It will contain the list of active profits at each moment of play

    public static int numProfits = 4;   //  Number of profits that must be active at all times during the game

    public int numGenerateProfits;  // Number of profits generated from the start of the game

    public static float profitScale_all = 4;    // profits scale
    public static Vector3 ProfitScale = new Vector3(profitScale_all, profitScale_all, profitScale_all);

    public static float profitLocalPosition_y = (1f / 2f) * ScGameGlobalData.profitScale_all; // Y coordinate is not random (all profits are at the same high)

    // Variables to define the names of the elements that we will save in memory
    private string group_near_label = "group_near_label";
    private string player_near_mode_label = "player_near_mode_label";
    private string profitsPlayer_Near_label = "profitsPlayer_Near_label";
    private string livesPlayer_Near_label = "livesPlayer_Near_label";

    private string group_far_label = "group_far_label";
    private string player_far_mode_label = "player_far_mode_label";
    private string profitsPlayer_Far_label = "profitsPlayer_Far_label";
    private string livesPlayer_Far_label = "livesPlayer_Far_label";

    private string timeLeftString_label = "timeLeftString_label";
    private string winner_label = "winner_label";

    // Use this for initialization
    /// <summary>
    /// ///////////  void Awake()
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - We initialize the variables of the game
    /// </summary>
    void Awake()
    {
        // //////////////////////////////////////////////
        // We initialize the game lists
       listTeam_Near = new List<gameElement>();
       listTeam_Far = new List<gameElement>();
       listProfits = new List<gameElement>();

        // //////////////////////////////////////////////
        // We initialize the "Game score data"
        profitsPlayer_Near = 0;
        profitsPlayer_Far = 0;

        livesPlayer_Near = initialLives;
        livesPlayer_Far = initialLives;

        // //////////////////////////////////////////////
        // We initialize the number of generated profits
        numGenerateProfits = 0;
    }  // Fin de - void Awake()

    // Use this for initialization
    void Start () {

        load_game();

    }  // FIn de - void Start()

    // Update is called once per frame
    void Update () {

    } // FIn de - void Update()


    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// //// load_game()
    ///     - To get memory data that may come from another scene
    ///     
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    /// </summary>
    private void load_game()
    {
        group_near = PlayerPrefs.GetString(group_near_label, "Undefined"); // To obtain string - SetString("name of the variable in memory", value that is assigned to the variable, if it was not defined)
        player_near_mode = PlayerPrefs.GetString(player_near_mode_label, "NPC");
        group_far = PlayerPrefs.GetString(group_far_label, "Undefined");
        player_far_mode = PlayerPrefs.GetString(player_far_mode_label, "NPC");
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// //// store_game()
    ///     - To record the data in memory so that it can be picked up from another scene
    ///     
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    /// </summary> 
    public void store_game(string timeLeftString, string winner)
    {
        PlayerPrefs.SetString(group_near_label, group_near);  // to store string - SetString("name of the variable in memory", value of the variable)
        PlayerPrefs.SetString(player_near_mode_label, player_near_mode);
        PlayerPrefs.SetInt(profitsPlayer_Near_label, profitsPlayer_Near);
        PlayerPrefs.SetInt(livesPlayer_Near_label, livesPlayer_Near);

        PlayerPrefs.SetString(group_far_label, group_far);
        PlayerPrefs.SetString(player_far_mode_label, player_far_mode);
        PlayerPrefs.SetInt(profitsPlayer_Far_label, profitsPlayer_Far);
        PlayerPrefs.SetInt(livesPlayer_Far_label, livesPlayer_Far);

        PlayerPrefs.SetString(timeLeftString_label, timeLeftString);  // to store string - SetString("name of the variable in memory", value of the variable)
        PlayerPrefs.SetString(winner_label, winner);  // to store string - SetString("name of the variable in memory", value of the variable)

    }

} // FIn de - public class ScGameGlobalData : MonoBehaviour {
