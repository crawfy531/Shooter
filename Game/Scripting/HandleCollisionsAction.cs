using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {            
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
                
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Spaceship player = (Spaceship)cast.GetFirstActor("player");
            Bullet bullet = (Bullet)cast.GetFirstActor("bullet");
            Target target = (Target)cast.GetFirstActor("target");
            Score score = (Score)cast.GetFirstActor("score");

            Point targetPosition = target.GetPosition();
            int targetX = targetPosition.GetX();
            int targetY = targetPosition.GetY();
            //makes sure there is a bullet
            if (player.GetShoot()){
                Point bulletPosition = bullet.GetPosition();
                int bulletY = bulletPosition.GetY();
                //detects if bullet hit target
                if(bulletPosition.Equals(targetPosition) 
                || bullet.GetPosition().Equals(new Point(targetX, targetY + Constants.CELL_SIZE))
                || bullet.GetPosition().Equals(new Point(targetX + Constants.CELL_SIZE, targetY))
                || bullet.GetPosition().Equals(new Point(targetX - Constants.CELL_SIZE, targetY))
                ){
                    //recreates target with a faster velocity at a random location at top
                    //makes bullet disapear on impact
                    target.GenerateRandomPosition();
                    target.IncreaseSpeedLimit();
                    score.AddPoints(100);
                    player.SetShoot(false);
                }
                //if bullet passes target it disapears
                if(bulletY == targetY
                || bulletY == targetY+Constants.CELL_SIZE){
                    player.SetShoot(false);
                }
            }
            //target has reached the bottom and initiates game over
            if(targetY == Constants.MAX_Y - Constants.CELL_SIZE){
                target.SetVelocity(new Point(0,0));
                isGameOver = true;
                bullet.SetColor(Constants.WHITE);
                target.SetColor(Constants.WHITE);
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);
                

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);
                
            }
        }

    }
}