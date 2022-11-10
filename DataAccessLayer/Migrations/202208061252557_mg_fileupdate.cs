namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_fileupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mechanics",
                c => new
                    {
                        MechanicId = c.Int(nullable: false, identity: true),
                        MechanicUserName = c.String(maxLength: 200),
                        MechanicPassword = c.String(maxLength: 200),
                        MechanicPhone = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MechanicId);
            
            AddColumn("dbo.MyFiles", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.MyFiles", "MechanicId", c => c.Int(nullable: false));
            CreateIndex("dbo.MyFiles", "UserId");
            CreateIndex("dbo.MyFiles", "MechanicId");
            AddForeignKey("dbo.MyFiles", "MechanicId", "dbo.Mechanics", "MechanicId", cascadeDelete: true);
            AddForeignKey("dbo.MyFiles", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            DropColumn("dbo.Users", "UserType");
            DropTable("dbo.Permissions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PermissionId);
            
            AddColumn("dbo.Users", "UserType", c => c.String(maxLength: 50));
            DropForeignKey("dbo.MyFiles", "UserId", "dbo.Users");
            DropForeignKey("dbo.MyFiles", "MechanicId", "dbo.Mechanics");
            DropIndex("dbo.MyFiles", new[] { "MechanicId" });
            DropIndex("dbo.MyFiles", new[] { "UserId" });
            DropColumn("dbo.MyFiles", "MechanicId");
            DropColumn("dbo.MyFiles", "UserId");
            DropTable("dbo.Mechanics");
        }
    }
}
