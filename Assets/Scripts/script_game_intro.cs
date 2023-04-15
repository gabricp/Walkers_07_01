using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Necessary to work with TextMeshPro

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////  
/// /////////// script_game_intro() : Contains the logic of the intro scene
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2023-03-11
/// Observations :
///     - walkers app home page
///     - This particular script contains the logic of the intro scene.
/// </summary>

public class script_game_intro : MonoBehaviour
{
    // work variables
    private string group_near;
    private string player_near_mode;
    private string group_far;
    private string player_far_mode;

    // Variables to define the names of the elements that we will save in memory
    private string group_near_label = "group_near_label";
    private string player_near_mode_label = "player_near_mode_label";
    private string group_far_label = "group_far_label";
    private string player_far_mode_label = "player_far_mode_label";

    // For the DropDown of the interface (you have to assign them, for example by dragging them in the graphical interface)
    public TMP_Dropdown group_near_Dropdown;  // You have to use "TMP_Dropdown" to get the options
    public TMP_Dropdown player_near_mode_Dropdown;
    public TMP_Dropdown group_far_Dropdown;
    public TMP_Dropdown player_far_mode_Dropdown;

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// ////  Awake() 
    /// 
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    ///         - This method is executed when generating the object that contains this script as a component
    /// </summary>
    private void Awake()
    {
        // Initialize job variables with a default value
        group_near = "Undefined";
        player_near_mode = "NPC";
        group_far = "Undefined";
        player_far_mode = "NPC";

        // We set an initial value to the variables that we are going to store in memory
        PlayerPrefs.SetString(group_near_label, group_near);
        PlayerPrefs.SetString(player_near_mode_label, player_near_mode);
        PlayerPrefs.SetString(group_far_label, group_far);
        PlayerPrefs.SetString(player_far_mode_label, player_far_mode);
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// ////  Start()
    /// 
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    ///         - This function is called on the first update of the object that contains this script as a component.
    /// </summary>
    void Start()
    {
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// ////  Update()
    /// 
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    ///         - This function is called once every frame.
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// //// store_intro()
    ///     - To record the data in memory so that it can be picked up from another scene
    ///     
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    /// </summary>
    private void store_intro()
    {
        PlayerPrefs.SetString(group_near_label, group_near);  // to store string - SetString("name of the variable in memory", value of the variable)
        PlayerPrefs.SetString(player_near_mode_label, player_near_mode);
        PlayerPrefs.SetString(group_far_label, group_far);
        PlayerPrefs.SetString(player_far_mode_label, player_far_mode);
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// //// load_intro()
    ///     - To get memory data that may come from another scene
    ///     
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    /// </summary>
    private void load_intro()
    {
        group_near = PlayerPrefs.GetString(group_near_label, "Undefined"); // To obtain string - SetString("name of the variable in memory", value that is assigned to the variable, if it was not defined)
        player_near_mode = PlayerPrefs.GetString(player_near_mode_label, "NPC");
        group_far = PlayerPrefs.GetString(group_far_label, "Undefined");
        player_far_mode = PlayerPrefs.GetString(player_far_mode_label, "NPC");
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// ////  button_pressed()
    ///     - Action when pressing the button
    ///     
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    ///         - Action when pressing the button, MUST BE ASSIGNED FROM THE GRAPHIC INTERFACE TO Button => OnClick
    /// </summary>
    public void button_pressed()
    {
        // We take the values of the form

        // Group near
        int selected_group_near = group_near_Dropdown.value;  // Using "TMP_Dropdown" to get the option
        if (selected_group_near == 0) { group_near = "Group 1"; }
        else if (selected_group_near == 1) { group_near = "Group 2"; }
        else if (selected_group_near == 2) { group_near = "Group 3"; }
        else if (selected_group_near == 3) { group_near = "Group 4"; }
        else if (selected_group_near == 4) { group_near = "Group 5"; }
        else if (selected_group_near == 5) { group_near = "Group 6"; }
        else if (selected_group_near == 6) { group_near = "Group 7"; }
        else
        {
            // error this option dosent exist
        }

        // Player near
        int selected_option_player_near = player_near_mode_Dropdown.value;  // Using "TMP_Dropdown" to get the option
        if (selected_option_player_near == 0) { player_near_mode = "User"; }
        else if (selected_option_player_near == 1) { player_near_mode = "NPC"; }
        else if (selected_option_player_near == 2) { player_near_mode = "randon"; }
        else
        {
            // error this option dosent exist
        }

        // Group far
        int selected_group_far = group_far_Dropdown.value;  // Using "TMP_Dropdown" to get the option
        if (selected_group_far == 0) { group_far = "Group 1"; }
        else if (selected_group_far == 1) { group_far = "Group 2"; }
        else if (selected_group_far == 2) { group_far = "Group 3"; }
        else if (selected_group_far == 3) { group_far = "Group 4"; }
        else if (selected_group_far == 4) { group_far = "Group 5"; }
        else if (selected_group_far == 5) { group_far = "Group 6"; }
        else if (selected_group_far == 6) { group_far = "Group 7"; }
        else
        {
            // error this option dosent exist
        }

        // Player far
        int selected_option_player_far = player_far_mode_Dropdown.value;  // Using "TMP_Dropdown" to get the option
        if (selected_option_player_far == 0) { player_far_mode = "User"; }
        else if (selected_option_player_far == 1) { player_far_mode = "NPC"; }
        else if (selected_option_player_far == 2) { player_far_mode = "randon"; }
        else
        {
            // error this option dosent exist
        }

        // We change scene
        SceneManager.LoadScene("Game_scene");
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// ////  OnDestroy()
    ///     - Action to execute before destroying this object
    ///     
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    ///         - It is executed before destroying the object, so here we take the opportunity to close what is necessary
    /// </summary>
    private void OnDestroy()
    {
        store_intro(); // We save the data so that it is available for other scenes
    }

}
