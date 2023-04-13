using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class increment_death : MonoBehaviour
{
    public int red_safe_standing_time = 0;
    public int blue_safe_standing_time = 0;
    public int red_unsafe_standing_time = 0;
    public int blue_unsafe_standing_time = 0;
    public int death = 0;
    public int death_by_spikes = 0;
    public int death_by_falling = 0;
    public int death_by_enemy = 0;
    public int death_by_spear = 0;
    public int death_by_crusher = 0;
    public int death_by_flying_monster = 0;
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

    public int jetpack_used_cnt_success = 0;
    public int rope_used_cnt_success = 0;
    public int spring_used_cnt_success = 0;

    public int teleporter_used_cnt_success = 0;

    public int number_of_attempt_left = 0;
    public string death_location_of_player = "";

    public int is_timeout = 0;

    public int is_level_completed = 0;
    public string coordinates_list;
    public string player_path;

    public string unsafe_platform_coordinates="";

    public int death_by_laser = 0;

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

    public void IncreaseDeathByFlyingMonster()
    {
        death_by_flying_monster++;
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

    public void IncreseTimeRedStandingSafe(int time)
    {
        red_safe_standing_time = time;
        Debug.Log(red_safe_standing_time);
    }

    public void IncreseTimeBlueStandingSafe(int time)
    {
        blue_safe_standing_time = time;
        Debug.Log(blue_safe_standing_time);
    }

    public void IncreseTimeRedStandingUnsafe(int time)
    {
        red_unsafe_standing_time = time;
        Debug.Log(red_unsafe_standing_time);
    }

    public void IncreseTimeBlueStandingUnsafe(int time)
    {
        blue_unsafe_standing_time = time;
        Debug.Log(blue_unsafe_standing_time);
    }
    public void IncreaseJetpackUsedCntSuccess()
    {
        jetpack_used_cnt_success++;
    }

    public void IncreaseRopeUsedCntSuccess()
    {
        rope_used_cnt_success++;
    }

    public void IncreaseSpringUsedCntSuccess()
    {
        spring_used_cnt_success++;
    }

    public void IncreaseTeleporterUsedCntSuccess()
    {
        teleporter_used_cnt_success++;
    }

    public void IncreaseNumberOfAttemptLeft()
    {
        number_of_attempt_left++;
    }

    public void IncreaseDeathLocationOfPlayer(float x, float y)
    {
        death_location_of_player += x.ToString() + ":" + y.ToString() + ",";

    }
    
    public void players_path(float x, float y)
    {
        string coordinates = "[" + x + "," + y + "],";
        coordinates_list += coordinates;
        player_path = coordinates_list;
    }

    public void IncreaseIsTimeout()
    {
        is_timeout++;
    }

    public void IncreaseIsLevelCompleted()
    {
        is_level_completed = 1;
    }

    public void IncreaseUnsafePlatformCoordinates(float x, float y)
    {
        unsafe_platform_coordinates += x.ToString() + ":" + y.ToString() + ",";
    }

    public void IncreaseDeathByLaser()
    {
        death_by_laser++;
    }

    public void ResetDeath()
    {
        death = 0;
        death_by_spikes = 0;
        death_by_falling = 0;
        death_by_enemy = 0;
        death_by_spear = 0;
        death_by_crusher = 0;
        death_by_explosive = 0;
        death_by_saw = 0;
        death_by_flying_monster = 0;
        time_to_complete_level = 0;
        death_by_puzzle = 0;
        level = 0;
        jetpack = 0;
        rope = 0;
        button_used = 0;
        teleporter_used = 0;
        spring_used = 0;
        ladder_used = 0;
        red_safe_standing_time = 0;
        blue_safe_standing_time = 0;
        red_unsafe_standing_time = 0;
        blue_unsafe_standing_time = 0;
        jetpack_used_cnt_success = 0;
        rope_used_cnt_success = 0;
        spring_used_cnt_success = 0;
        teleporter_used_cnt_success = 0;
        number_of_attempt_left = 0;
        death_location_of_player = "";
        is_timeout = 0;
        is_level_completed = 0;
        coordinates_list = "";
        unsafe_platform_coordinates = "";
        death_by_laser = 0;
        Movement.jetpackDuration = 1.5f;
        Movement.elapsedTime = 0f;
        Weapon.allowed_shots = 500;
        Movement.push_force = true;
    }
}
