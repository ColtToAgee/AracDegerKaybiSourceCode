namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_lawyer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lawyers",
                c => new
                    {
                        LawyerId = c.Int(nullable: false, identity: true),
                        LawyerUsername = c.String(maxLength: 200),
                        LawyerPassword = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.LawyerId);
            
            AddColumn("dbo.Users", "LawyerId", c => c.Int());
            CreateIndex("dbo.Users", "LawyerId");
            AddForeignKey("dbo.Users", "LawyerId", "dbo.Lawyers", "LawyerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "LawyerId", "dbo.Lawyers");
            DropIndex("dbo.Users", new[] { "LawyerId" });
            DropColumn("dbo.Users", "LawyerId");
            DropTable("dbo.Lawyers");
        }
    }
}
