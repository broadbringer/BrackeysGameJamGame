using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game.GameSession;
using Assets.Scripts.Game.ScriptableObjects;
using UnityEngine;

public class GameEconomy 
{
   public int DayIndex;
   private float DayIncome;
   private int DayCassetGoal;
   
   private List<int> _deltasForDayCassetsGoal = new List<int>
   {
      4,15,120,240,480
   };

   #region CassetsGoalEconomy
   private int GetDayCassettGoalInSuccessfulDay()
   {
      if (DayIndex < 7)
      {
         DayCassetGoal += _deltasForDayCassetsGoal[0];
      }
      else if (DayIndex >= 7 && DayIndex < 12)
      {
         DayCassetGoal += _deltasForDayCassetsGoal[1];
      }
      else if (DayIndex >= 12 && DayIndex < 18)
      {
         DayCassetGoal += _deltasForDayCassetsGoal[2];
      }
      else if (DayIndex >= 18 && DayIndex < 23)
      {
         DayCassetGoal += _deltasForDayCassetsGoal[3];
      }
      else
      {
         DayCassetGoal += _deltasForDayCassetsGoal[4];
      }

      return DayCassetGoal;
   }

   private int GetDayCassettGoalInUnsuccessfulDay(GameSessionData gameData)
   {
      var delta = gameData.SpinnedCassettsGoal - gameData.SpinnedCassetts;
      return delta;
   }
   public void SetNextDayCassettGoal(GameSessionData gameData)
   {
      gameData.SpinnedCassettsGoal = gameData.SpinnedCassetts != gameData.SpinnedCassettsGoal ? GetDayCassettGoalInUnsuccessfulDay(gameData) : GetDayCassettGoalInSuccessfulDay();
   }
   

   #endregion

   #region MoneyEconomy

   private float GetIncome(GameSessionData gameData)
   {
      return gameData.SpinnedCassetts * gameData.OneCassettPrice;
   }

   public void SetMoney(GameSessionData gameData)
   {
      gameData.Money += GetIncome(gameData);
   }
   #endregion
}
