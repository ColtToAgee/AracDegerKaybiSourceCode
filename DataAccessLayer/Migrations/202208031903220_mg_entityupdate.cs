namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_entityupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Username", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "UserType", c => c.String(maxLength: 50));
            DropColumn("dbo.Users", "Name_Surname");
            DropColumn("dbo.Users", "Birthday");
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "Birthday", c => c.String());
            AddColumn("dbo.Users", "Name_Surname", c => c.String(maxLength: 100));
            DropColumn("dbo.Users", "UserType");
            DropColumn("dbo.Users", "Username");
        }
    }
}
