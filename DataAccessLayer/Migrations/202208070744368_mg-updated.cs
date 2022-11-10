namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgupdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MyFiles", "MechanicId", "dbo.Mechanics");
            DropIndex("dbo.MyFiles", new[] { "MechanicId" });
            AddColumn("dbo.Users", "MechanicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "MechanicId");
            AddForeignKey("dbo.Users", "MechanicId", "dbo.Mechanics", "MechanicId", cascadeDelete: true);
            DropColumn("dbo.MyFiles", "MechanicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyFiles", "MechanicId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "MechanicId", "dbo.Mechanics");
            DropIndex("dbo.Users", new[] { "MechanicId" });
            DropColumn("dbo.Users", "MechanicId");
            CreateIndex("dbo.MyFiles", "MechanicId");
            AddForeignKey("dbo.MyFiles", "MechanicId", "dbo.Mechanics", "MechanicId", cascadeDelete: true);
        }
    }
}
