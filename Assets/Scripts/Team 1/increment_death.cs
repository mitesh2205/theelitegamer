using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increment_death : MonoBehaviour
{
    public int death = 0;
    public int death_by_spikes = 0;
    public int death_by_falling = 0;
    public int death_by_enemy = 0;
    public int death_by_spear = 0;
    public int death_by_crusher = 0;
    public int death_by_explosive = 0;
    public int death_by_saw = 0;
    public int time_to_complete_level = 0;
    public int death_by_puzzle = 0;
    public int level = 0;
    public int jetpack = 0;
    public int rope = 0;
    public int button_used = 0;
    public int teleporter_used = 0;
    public int spring_used = 0;
    public int ladder_used = 0;

    public void IncreaseDeath()
    {
        death++;
    }

    public void IncreaseDeathBySpikes()
    {
        death_by_spikes++;
    }
    
    public void IncreaseDeathByFalling()
    {
        death_by_falling++;
    }

    public void IncreaseDeathByEnemy()
    {
        death_by_enemy++;
    }

    public void IncreaseDeathBySpear()
    {
        death_by_spear++;
    }

    public void IncreaseDeathByCrusher()
    {
        death_by_crusher++;
    }

    public void IncreaseDeathByExplosive()
    {
        death_by_explosive++;
    }

    public void IncreaseDeathBySaw()
    {
        death_by_saw++;
    }

    public void IncreaseTimeToCompleteLevel(int time_difference)
    {
        time_to_complete_level = time_difference;  
        Debug.Log(time_to_complete_level);   
    }

    public void IncreaseDeathByPuzzle()
    {
        death_by_puzzle++;
    }

    public void IncreaseLevel(int level)
    {
        this.level = level;
        // level++;
    }

    public void IncreaseJetpack()
    {
        jetpack++;
    }

    public void IncreaseRope()
    {
        rope++;
    }

    public void IncreaseButtonUsed()
    {
        button_used++;
    }

    public void IncreaseTeleporterUsed()
    {
        teleporter_used++;
    }

    public void IncreaseSpringUsed()
    {
        spring_used++;
    }

    public void IncreaseLadderUsed()
    {
        ladder_used++;
    }



    // public void ResetDeath()
    // {
    //     death = 0;
    //     death_by_spikes = 0;
    //     death_by_falling = 0;
    //     death_by_enemy = 0;
    //     death_by_spear = 0;
    //     death_by_crusher = 0;
    //     death_by_explosive = 0;
    //     death_by_saw = 0;
    //     time_to_complete_level = 0;
    //     death_by_puzzle = 0;
    //     level = 0;
    //     jetpack = 0;
    //     rope = 0;
    //     button_used = 0;
    //     teleporter_used = 0;
    //     spring_used = 0;
    //     ladder_used = 0;
    // }
}
