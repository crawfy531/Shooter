using System;
namespace Unit05.Game.Casting{
    public class Target: Actor{
            private int speedlimit = 20;
            private int speedRate = 1;
            private int speed = 0;
            //creats a new instance of a target
        public Target(){
            SetText("O");
            SetColor(Constants.GREEN);
            GenerateRandomPosition();
            
        }
        //generates where the target will be put at the top of the screen in a random x coordinate
        public void GenerateRandomPosition(){
            Random r = new Random();
            int xPosition = r.Next(0,60);
            int xPositionUnit = xPosition * Constants.CELL_SIZE;
            SetPosition(new Point(xPositionUnit,Constants.MAX_Y+Constants.CELL_SIZE));
        }
        //controls the velocity of the target by only allowing it to move at certain frames
        public void ControlSpeed(){
            if(speed >= speedlimit){
                SetVelocity(new Point(0,Constants.CELL_SIZE));
                speed=0;
            }
            else{
                SetVelocity(new Point(0,0));
                speed+=speedRate;
            }
        }
        //increases the velocity of the target falling
                public void IncreaseSpeedLimit(){
                speedRate+= 1;
        }

    }
}