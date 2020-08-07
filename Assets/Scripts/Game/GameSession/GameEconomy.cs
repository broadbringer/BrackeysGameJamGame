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

   private float _delta = 0.5f;
   public GameEconomy()
   {
      DayCassetGoal = 20;
   }

   #region CassetsGoalEconomy
   private int GetDayCassettGoalInSuccessfulDay()
   {
      DayCassetGoal += (int)(DayCassetGoal * _delta);

      return DayCassetGoal;
   }

   private int GetDayCassettGoalInUnsuccessfulDay(GameSessionData gameData)
   {
      var delta = gameData.SpinnedCassettsGoal - gameData.SpinnedCassetts;
      DayCassetGoal =  delta;
      return DayCassetGoal;
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

   public void PaySalary(GameSessionData gameData, float value)
   {
      gameData.Money -= value;
   }
   #endregion
}
