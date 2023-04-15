﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// /////////// public class ScGameControl
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
///     - Controls the execution of the game
/// </summary>
public class ScGameControl : MonoBehaviour {

    public Text txt_profitsPlayer_Near;
    public Text txt_profitsPlayer_Far;
    public Text txt_livesPlayer_Near;
    public Text txt_livesPlayer_Far;
    public Text txt_timeLeft;

    double timeLeft;
    public string timeLeftString; // Remaining game time

    // Use this for initialization
    /// <summary>
    /// ///////////  void Start 
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - We generate the elements of the game
    /// </summary>
    void Start () {

        // ///////////////////////////////
        // Teams generation
        GameObject Team_Far = Instantiate(GetComponent<ScGameGlobalData>().Team_Far);
        Team_Far.name = "Team_Far";
        Team_Far.GetComponent<ScTeamControl>().nuemroTeam = 1;
        GameObject Team_Near = Instantiate(GetComponent<ScGameGlobalData>().Team_Near);
        Team_Near.name = "Team_Near";
        Team_Near.GetComponent<ScTeamControl>().nuemroTeam = 2;

    } // FIn de - void Start()

    // Update is called once per frame
    /// <summary>
    /// ///////////  void Update
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - We controls the execution of the game
    /// </summary>
    void Update () {

        // we get the current time
        DateTime actualDate;
        actualDate = DateTime.Now; // Instant now
        // we get the playing time so far
        TimeSpan timePlayng = actualDate - ScGameGlobalData.initialDate;
        double timePlayng_ms = timePlayng.TotalMilliseconds;  // Time playing in microseconds

        timeLeft = (ScGameGlobalData.maxGameTime_ms - timePlayng_ms)/1000; // Time to the end of the play
        timeLeftString = timeLeft.ToString();
        if (timeLeft < 0) { timeLeftString = "0"; }

        // Bookmark update
        txt_profitsPlayer_Near.text = "Team Near Profits :" + GetComponent<ScGameGlobalData>().profitsPlayer_Near;
        txt_profitsPlayer_Far.text = "Team Far Profits : " + GetComponent<ScGameGlobalData>().profitsPlayer_Far;
        txt_livesPlayer_Near.text = "Team Near lives : " + GetComponent<ScGameGlobalData>().livesPlayer_Near;
        txt_livesPlayer_Far.text = "Team Far :lives : " + GetComponent<ScGameGlobalData>().livesPlayer_Far;
        txt_timeLeft.text = "Time left : " + timeLeftString;

        // We controls if the game has ended by time
        if (timePlayng_ms > ScGameGlobalData.maxGameTime_ms)
        {
            Debug.Log(" The game is over for a time limit with profits Player Near = " +
                GetComponent<ScGameGlobalData>().profitsPlayer_Near +
                " - profits Player Far = " + GetComponent<ScGameGlobalData>().profitsPlayer_Far +
                " - lives Player Near = " + GetComponent<ScGameGlobalData>().livesPlayer_Near +
                " - lives Player Far = " + GetComponent<ScGameGlobalData>().livesPlayer_Far );
            Time.timeScale = 0;
            game_over();
        }// We controls if the game has ended by lives
        else if ((GetComponent<ScGameGlobalData>().livesPlayer_Near <= 0) || (GetComponent<ScGameGlobalData>().livesPlayer_Far <= 0))
        {
            Debug.Log(" The game has ended by death in time = " + timeLeftString + " Seconds " +
                " - profits Player Near = " + GetComponent<ScGameGlobalData>().profitsPlayer_Near +
                " - profits Player Far = " + GetComponent<ScGameGlobalData>().profitsPlayer_Far +
                " - lives Player Near = " + GetComponent<ScGameGlobalData>().livesPlayer_Near +
                " - lives Player Far = " + GetComponent<ScGameGlobalData>().livesPlayer_Far);
            Time.timeScale = 0;
            game_over();
        }

    } // FIn de - void Update()

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  giveToMeRandomPosition()
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - Attention:
    ///         - X : width
    ///         - y : high
    ///         - z : length
    ///     - If you ned a random position in X and Z only. You mast to overwrite the Y coordinate of Vector3 returned
    /// Inputs :
    /// Outputs:
    ///     - Vector3 (position) - is a Vector3 
    /// </summary>
    public static Vector3 giveToMeGameInfo()
    {
        // We generate its position randomly
        float range_X = Random.Range(-1f, 1f);
        float range_Y = Random.Range(-1f, 1f);
        float range_Z = Random.Range(-1f, 1f);
        float position_X = range_X * (1f / 2f) * ScGameGlobalData.GS_scale_X * 10f; // Plane dimension is 10 squares in X and Z
        float position_Y = range_Y * (1f / 2f) * ScGameGlobalData.GS_scale_Y; ;
        float position_Z = range_Z * (1f / 2f) * ScGameGlobalData.GS_scale_Z * 10f; // Plane dimension is 10 squares in X and Z

        Vector3 position = new Vector3(position_X, position_Y, position_Z);

        return position;
    } // FIn de - public static Vector3 giveToMeRandomPosition()

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// ///////////  giveToMeRandomPosition()
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - IT IS NOT AN ARTIFICIAL INTELLIGENT SCRIPT
    ///     - Attention:
    ///         - X : width
    ///         - y : high
    ///         - z : length
    ///     - If you ned a random position in X and Z only. You mast to overwrite the Y coordinate of Vector3 returned
    /// Inputs :
    /// Outputs:
    ///     - Vector3 (position) - is a Vector3 
    /// </summary>
    public static Vector3 giveToMeRandomPosition()
    {
        // We generate its position randomly
        float range_X = Random.Range(-1f, 1f);
        float range_Y = Random.Range(-1f, 1f);
        float range_Z = Random.Range(-1f, 1f);
        float position_X = range_X * (1f / 2f) * ScGameGlobalData.GS_scale_X * 10f; // Plane dimension is 10 squares in X and Z
        float position_Y = range_Y * (1f / 2f) * ScGameGlobalData.GS_scale_Y; ;
        float position_Z = range_Z * (1f / 2f) * ScGameGlobalData.GS_scale_Z * 10f; // Plane dimension is 10 squares in X and Z

        Vector3 position = new Vector3(position_X, position_Y, position_Z);

        return position;
    } // FIn de - public static Vector3 giveToMeRandomPosition()

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// //// game_over()
    ///     - The game is over and we go to the credits scene
    ///     
    /// Auttor : Miguel Angel Fernandez Graciani
    /// Creation date : 2023-03-11
    /// Last modification :
    /// Input parameters :
    /// Output parameters :
    /// Observations:
    /// </summary>
    private void game_over()
    {
        string winner;

        // Si uno de los players se ha quedado sin vidas, el ganador es el otro equipo
        if((GetComponent<ScGameGlobalData>().livesPlayer_Near <= 0) & (GetComponent<ScGameGlobalData>().livesPlayer_Far > 0)){ winner = ScGameGlobalData.idTeam_Far; }
        else if ((GetComponent<ScGameGlobalData>().livesPlayer_Far <= 0) & (GetComponent<ScGameGlobalData>().livesPlayer_Near > 0)) { winner = ScGameGlobalData.idTeam_Near; }
        // Si ningun player se ha quedado sin vidas es que el juego ha finalizado por tiempo, gana el que mas puntos tenga, si empatan en puntos, el que temngas mas vidas
        // y si tienen las mismas es empate
        else
        {
            if (GetComponent<ScGameGlobalData>().profitsPlayer_Near > GetComponent<ScGameGlobalData>().profitsPlayer_Far) { winner = ScGameGlobalData.idTeam_Near; }
            else if (GetComponent<ScGameGlobalData>().profitsPlayer_Far > GetComponent<ScGameGlobalData>().profitsPlayer_Near) { winner = ScGameGlobalData.idTeam_Far; }
            else if (GetComponent<ScGameGlobalData>().livesPlayer_Near > GetComponent<ScGameGlobalData>().livesPlayer_Far) { winner = ScGameGlobalData.idTeam_Near; }
            else if (GetComponent<ScGameGlobalData>().livesPlayer_Far > GetComponent<ScGameGlobalData>().livesPlayer_Near) { winner = ScGameGlobalData.idTeam_Far; }
            else { winner = "TIE"; }
        }

        // We store game data so that the title scene can access it
        GetComponent<ScGameGlobalData>().store_game(timeLeftString, winner);

        // We change scene
        SceneManager.LoadScene("Title_scene");
    }

} // Fin de - public class ScGameControl : MonoBehaviour {
