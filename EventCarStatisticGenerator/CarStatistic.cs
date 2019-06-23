using System;

namespace EventCarStatisticGenerator
{
    public class CarStatistic
    {
        public Guid GuId { get; set; }
        public int CarId { get; set; }
        public int Speed { get; set; }
        public int Acceleration { get; set; }
        public int Braking { get; set; }

        public CarStatistic() { }
        public CarStatistic(CarStatistic previous)
        {
            Random random = new Random();
            this.GuId = Guid.NewGuid();
            this.CarId = previous.CarId;
            int isBraking = 0;
            isBraking = random.Next(15);
            if (previous.Braking > 0)
                isBraking += 2;

            if (isBraking >= 15)
            {
                this.Braking = 100;
                this.Acceleration = 0;
                if (random.Next(0, 1) == 0) { this.Speed = 0; }
                else { this.Speed = previous.Speed / 3; }
            }

            if (isBraking < 11)
            {
                this.Braking = 0;
                this.Acceleration = Math.Abs(previous.Acceleration + random.Next(-15, 15));
                this.Speed = Math.Abs(previous.Speed + (this.Acceleration - previous.Acceleration) * 2);

            }

            if (isBraking >= 11 && isBraking < 15)
            {
                this.Acceleration = 0;
                this.Braking = random.Next(10, 70);
                this.Speed = Math.Abs(previous.Speed - this.Braking / 2);
            }


        }

    }
}
