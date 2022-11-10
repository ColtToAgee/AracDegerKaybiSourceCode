namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_myadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyFiles", "MyFileName", c => c.String(maxLength: 200));
            AddColumn("dbo.MyFiles", "MyFilePath", c => c.String(maxLength: 200));
            DropColumn("dbo.MyFiles", "FileName");
            DropColumn("dbo.MyFiles", "FilePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyFiles", "FilePath", c => c.String(maxLength: 200));
            AddColumn("dbo.MyFiles", "FileName", c => c.String(maxLength: 200));
            DropColumn("dbo.MyFiles", "MyFilePath");
            DropColumn("dbo.MyFiles", "MyFileName");
        }
    }
}
