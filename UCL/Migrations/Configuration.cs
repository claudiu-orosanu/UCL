namespace UCL.Migrations
{
    using Model.Nomenclatures;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UCL;

    internal sealed class Configuration : DbMigrationsConfiguration<UCL.UCLContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UCL.UCLContext context)
        {
            PopulatePositionEnum(context);
        }

        private void PopulatePositionEnum(UCL.UCLContext context)
        {
            var positionList = new List<Position>
            {
                new Position {Id = 1, Name = "Forward" },
                new Position {Id = 2, Name = "Midfielder" },
                new Position {Id = 3, Name = "Defender" },
                new Position {Id = 4, Name = "Goalkeeper" }
            };

            foreach (var position in positionList)
            {
                context.Positions.AddOrUpdate(p => p.Name, position);
            }
        }
    }
}
