namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewMovie1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genres", "Name");
        }
    }
}
