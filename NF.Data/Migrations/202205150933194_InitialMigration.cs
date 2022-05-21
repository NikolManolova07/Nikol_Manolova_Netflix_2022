namespace NF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Director",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        IsFamous = c.Boolean(nullable: false),
                        DirectorInfo = c.String(maxLength: 1000),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ReleaseDate = c.DateTime(),
                        ReleaseCountry = c.String(maxLength: 50),
                        DirectorId = c.Int(nullable: false),
                        ProducerId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        MovieInfo = c.String(maxLength: 1000),
                        RatingId = c.Int(nullable: false),
                        IsOscarWinner = c.Boolean(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Director", t => t.DirectorId, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Producer", t => t.ProducerId, cascadeDelete: true)
                .ForeignKey("dbo.Rating", t => t.RatingId, cascadeDelete: true)
                .Index(t => t.DirectorId)
                .Index(t => t.ProducerId)
                .Index(t => t.GenreId)
                .Index(t => t.RatingId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        GenreInfo = c.String(maxLength: 500),
                        IsPopular = c.Boolean(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        IsFamous = c.Boolean(nullable: false),
                        ProducerInfo = c.String(maxLength: 1000),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Status = c.Double(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "RatingId", "dbo.Rating");
            DropForeignKey("dbo.Movie", "ProducerId", "dbo.Producer");
            DropForeignKey("dbo.Movie", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Movie", "DirectorId", "dbo.Director");
            DropIndex("dbo.Movie", new[] { "RatingId" });
            DropIndex("dbo.Movie", new[] { "GenreId" });
            DropIndex("dbo.Movie", new[] { "ProducerId" });
            DropIndex("dbo.Movie", new[] { "DirectorId" });
            DropTable("dbo.Rating");
            DropTable("dbo.Producer");
            DropTable("dbo.Genre");
            DropTable("dbo.Movie");
            DropTable("dbo.Director");
        }
    }
}
