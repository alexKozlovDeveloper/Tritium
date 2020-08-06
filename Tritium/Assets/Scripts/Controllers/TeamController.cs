using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    public int TeamId;

    public bool IsEnemy(GameObject player)
    {
        var teamController = player.GetComponent<TeamController>();

        if(teamController == null)
        {
            return false;
        }

        if(teamController.TeamId != TeamId)
        {
            return true;
        }

        return false;
    }
}
