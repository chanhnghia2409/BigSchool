namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Place = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        Time = c.String(nullable: false),
                        Category = c.Byte(nullable: false),
                        Heading = c.String(),
                        searching = c.String(),
                        ShowAction = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Attendances", "CourseViewModel_Id", c => c.Int());
            AddColumn("dbo.Followings", "CourseViewModel_Id", c => c.Int());
            AddColumn("dbo.Followings", "CourseViewModel_Id1", c => c.Int());
            CreateIndex("dbo.Attendances", "CourseViewModel_Id");
            CreateIndex("dbo.Followings", "CourseViewModel_Id");
            CreateIndex("dbo.Followings", "CourseViewModel_Id1");
            AddForeignKey("dbo.Attendances", "CourseViewModel_Id", "dbo.CourseViewModels", "Id");
            AddForeignKey("dbo.Followings", "CourseViewModel_Id", "dbo.CourseViewModels", "Id");
            AddForeignKey("dbo.Followings", "CourseViewModel_Id1", "dbo.CourseViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "CourseViewModel_Id1", "dbo.CourseViewModels");
            DropForeignKey("dbo.Followings", "CourseViewModel_Id", "dbo.CourseViewModels");
            DropForeignKey("dbo.Attendances", "CourseViewModel_Id", "dbo.CourseViewModels");
            DropIndex("dbo.Followings", new[] { "CourseViewModel_Id1" });
            DropIndex("dbo.Followings", new[] { "CourseViewModel_Id" });
            DropIndex("dbo.Attendances", new[] { "CourseViewModel_Id" });
            DropColumn("dbo.Followings", "CourseViewModel_Id1");
            DropColumn("dbo.Followings", "CourseViewModel_Id");
            DropColumn("dbo.Attendances", "CourseViewModel_Id");
            DropTable("dbo.CourseViewModels");
        }
    }
}
