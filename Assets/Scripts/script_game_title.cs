using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Necessary to work with TextMeshPro

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////  
/// /////////// script_game_title() : Contains the logic of the title scene
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2023-03-11
/// Observations :
///     - This particular script contains the logic of the title scene.
/// </summary>

public class script_game_title : MonoBehaviour
{
    // For the text boxes of the interface (you have to assign them, for example by dragging them in the graphical interface)
    public TMP_Text Value_group_near;  // You have to use "TMP_InputField" to get text from a text box
    public TMP_Text Value_player_near_mode;
    public TMP_Text Value_profitsPlayer_Near;
    public TMP_Text Value_livesPlayer_Near;
    public TMP_Text Value_group_far;
    public TMP_Text Value_player_far_mode;
    public TMP_Text Value_profitsPlayer_Far;
    public TMP_Text Value_livesPlayer_Far;
    public TMP_Text Value_timeLeftString;
    public TMP_Text Value_winner_label;

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

    // Start is called before the first frame update
    void Start()
    {
        load_title();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// //// load_title()
    ///     - To get memory data that may come from another scene
    ///     
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    /// </summary>
    private void load_title()
    {
        Value_group_near.text = PlayerPrefs.GetString(group_near_label, "Undefined"); // To obtain string - SetString("name of the variable in memory", value that is assigned to the variable, if it was not defined)
        Value_player_near_mode.text = PlayerPrefs.GetString(player_near_mode_label, "Undefined");
        Value_profitsPlayer_Near.text = PlayerPrefs.GetInt(profitsPlayer_Near_label, 0).ToString();
        Value_livesPlayer_Near.text = PlayerPrefs.GetInt(livesPlayer_Near_label, 0).ToString();
        Value_group_far.text = PlayerPrefs.GetString(group_far_label, "Undefined");
        Value_player_far_mode.text = PlayerPrefs.GetString(player_far_mode_label, "Undefined");
        Value_profitsPlayer_Far.text = PlayerPrefs.GetInt(profitsPlayer_Far_label, 0).ToString();
        Value_livesPlayer_Far.text = PlayerPrefs.GetInt(livesPlayer_Far_label, 0).ToString();
        Value_timeLeftString.text = PlayerPrefs.GetString(timeLeftString_label, "Undefined");
        Value_winner_label.text = PlayerPrefs.GetString(winner_label, "Undefined");
    }

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  exit game
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
/// </summary>
public void exitGame()
    {
        Application.Quit();

    } // FIn de - protected void exitGame()


}
