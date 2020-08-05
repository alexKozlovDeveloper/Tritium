using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    public string TeamName;

    public bool IsEnemy(GameObject player)
    {
        var teamController = player.GetComponent<TeamController>();

        if(teamController == null)
        {
            return false;
        }

        if(teamController.TeamName != TeamName)
        {
            return true;
        }

        return false;
    }
}
