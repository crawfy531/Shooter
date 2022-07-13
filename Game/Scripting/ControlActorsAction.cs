using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);
        private Point direction2 = new Point(Constants.CELL_SIZE, 0);
        private int growthrate = 0;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Spaceship player = (Spaceship)cast.GetFirstActor("player");
            Bullet bullet = (Bullet)cast.GetFirstActor("bullet");
            Target target= (Target)cast.GetFirstActor("target");
            // sets the speed the target is falling
            target.ControlSpeed();
            //moves the spaceship left and
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }
            // right
            if (keyboardService.IsKeyDown("d"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            // activates the ship to shoot the bullet
            if (keyboardService.IsKeyDown("w"))
            {
                if(!player.GetShoot() == true){
                    player.SetShoot(true);
                    //bullet.SetPosition(player.GetPosition());
                }


            }
            if (!keyboardService.IsKeyDown("a") && !keyboardService.IsKeyDown("d"))
            {
                direction = new Point(0,0);
            }
            //activates the movement
            player.SetVelocity(direction);
        }
    }
}