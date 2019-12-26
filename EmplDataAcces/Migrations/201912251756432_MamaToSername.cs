namespace EmplDataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MamaToSername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Sername", c => c.String());
            DropColumn("dbo.Employees", "Mama");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Mama", c => c.String());
            DropColumn("dbo.Employees", "Sername");
        }
    }
}
