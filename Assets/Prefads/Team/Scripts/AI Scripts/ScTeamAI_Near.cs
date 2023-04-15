using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
/// Author : 	Miguel Angel Fernandez Graciani
/// Date :	2021-02-07
/// Observations :
///     - THIS IS AN ARTIFICIAL INTELLIGENT SCRIPT
///     - You must implement the necessary algorithm
///     - You must Change it to define the artiicial intelligence of this Team
/// </summary>
public class ScTeamAI_Near : MonoBehaviour {

    public GameObject Game;  // To access to the general object "Game"

    public List<gameElement> Teammates_list;
    public List<gameElement> opponents_list;

    // Use this for initialization
    /// <summary>
    /// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
    /// Author : 	
    /// Date :	
    /// Observations :
    /// </summary>
    void Start()
    {

        // We access to the general object "Game"
        Game = GameObject.FindWithTag("Game");

        // if we are team near: (if you are not, comment these two lines)
//        Teammates_list = Game.GetComponent<ScGameGlobalData>().listTeam_Near;
//        opponents_list = Game.GetComponent<ScGameGlobalData>().listTeam_Far;

        // if we are team far: (if you are not, comment these two lines)
        Teammates_list = Game.GetComponent<ScGameGlobalData>().listTeam_Far;
        opponents_list = Game.GetComponent<ScGameGlobalData>().listTeam_Near;

    }  // FIn de - void Start()

    // Update is called once per frame
    /// <summary>
    /// /////  void Update () {
    /// ///////////  ARTIFICIAL INTELLIGENCE  MINION Script 
    /// Author : 	Miguel Angel Fernandez Graciani
    /// Date :	2021-02-07
    /// Observations :
    ///     - Here we show how you can access the the information regarding the elements in game
    /// </summary>
    void Update()
    {

        // You can access to the information of all elements in the game using sentences lake the following
        /*
        foreach (gameElement element_mate in Teammates_list)
        {
            Vector3 posicion = element_mate.giveToMePosition();
            Debug.Log("vector x :" + posicion.x.ToString());
            Debug.Log("In Teammates : " +
                " - element_mate - label : " + element_mate.giveToMeTag() +
                " - element_mate - id : " + element_mate.giveToMeId() +
                " - element_mate - Team : " + element_mate.giveToMeTeam() +
                " - element_mate position x : " + posicion.x +
                " - element_mate position z : " + posicion.z +
                " - element_mate position y : " + posicion.y);
        }  // Fin de - foreach (gameElement element_mate in Teammates_list)

        foreach (gameElement element_opponent in opponents_list)
        {
            Vector3 posicion = element_opponent.giveToMePosition();
            Debug.Log("vector x :" + posicion.x.ToString());
            Debug.Log("In team Far : " +
                " - element_opponent - label : " + element_opponent.giveToMeTag() +
                " - element_opponent - id : " + element_opponent.giveToMeId() +
                " - element_opponent - Team : " + element_opponent.giveToMeTeam() +
                " - element_opponent posicion x : " + posicion.x +
                " - element_opponent posicion z : " + posicion.z +
                " - element_opponent posicion y : " + posicion.y);
        }  // Fin de - foreach (gameElement element_mate in Teammates_list)

        foreach (gameElement elementProfit in Game.GetComponent<ScGameGlobalData>().listProfits)
        {
            Vector3 posicion = elementProfit.giveToMePosition();
            Debug.Log("vector x :" + posicion.x.ToString());
            Debug.Log("In profits : " +
                " - element profit - label : " + elementProfit.giveToMeTag() +
                " - element profit - id : " + elementProfit.giveToMeId() +
                " - element profit - Team : " + elementProfit.giveToMeTeam() +
                " - element profit posicion x : " + posicion.x +
                " - element profit posicion z : " + posicion.z +
                " - element profit posicion y : " + posicion.y);
        }  // Fin de - foreach (gameElement element_mate in Teammates_list)
        */
    }  // FIn de - void Update()

}  // Fin de - public class ScTeamAI_Near : MonoBehaviour {
