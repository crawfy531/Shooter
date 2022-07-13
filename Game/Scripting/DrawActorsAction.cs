using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;
        bool shoot;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Spaceship player = (Spaceship)cast.GetFirstActor("player");
            cast.AddActor("bullet", new Bullet());
            Target target = (Target)cast.GetFirstActor("target");
            Bullet bullet = (Bullet)cast.GetFirstActor("bullet");
            Actor score = cast.GetFirstActor("score");
            //creates a bullet from spaceship
            if(player.GetShoot()){
                videoService.DrawActor(bullet);
                Point bulletPosition = bullet.GetPosition();
                //makes bullet disapear when it gets to the top of the screen
                if(bulletPosition.GetY() == 0){
                    player.SetShoot(false);
                    bullet.SetPosition(player.GetPosition());
                }
            }
            //prepares to shoot bullet
            else{
                bullet.SetPosition(player.GetPosition());
            }
            //draws all actors
            List<Actor> messages = cast.GetActors("messages");
            videoService.ClearBuffer();
            videoService.DrawActor(score);
            videoService.DrawActors(messages);
            videoService.DrawActor(player);
            videoService.DrawActor(target);
            videoService.FlushBuffer();
        }
        public void Shootbullet(){
            shoot = true;
        }
    }
}