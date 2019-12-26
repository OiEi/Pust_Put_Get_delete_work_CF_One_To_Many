namespace EmplDataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Mama", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Mama");
        }
    }
}
