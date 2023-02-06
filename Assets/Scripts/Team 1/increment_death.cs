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
    // }
}
