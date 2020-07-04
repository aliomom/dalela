namespace NawafizApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        branchArabicName = c.String(maxLength: 4000),
                        branchEnglishName = c.String(maxLength: 4000),
                        branchFrenchName = c.String(maxLength: 4000),
                        branchRussName = c.String(maxLength: 4000),
                        branchPersianName = c.String(maxLength: 4000),
                        facebookLink = c.String(maxLength: 4000),
                        instaLink = c.String(maxLength: 4000),
                        email1 = c.String(maxLength: 4000),
                        email2 = c.String(maxLength: 4000),
                        phone1 = c.String(maxLength: 4000),
                        phone2 = c.String(maxLength: 4000),
                        phone3 = c.String(maxLength: 4000),
                        longtitude = c.Decimal(nullable: false, precision: 18, scale: 10),
                        latitude = c.Decimal(nullable: false, precision: 18, scale: 10),
                        outDays = c.String(maxLength: 4000),
                        StartActiveTime = c.Time(nullable: false, precision: 7),
                        EndActiveTime = c.Time(nullable: false, precision: 7),
                        ShopDalId = c.Int(nullable: false),
                        NeighborhoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Neighborhood", t => t.NeighborhoodId, cascadeDelete: true)
                .ForeignKey("dbo.ShopDal", t => t.ShopDalId, cascadeDelete: true)
                .Index(t => t.ShopDalId)
                .Index(t => t.NeighborhoodId);
            
            CreateTable(
                "dbo.Break",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        start = c.Time(nullable: false, precision: 7),
                        end = c.Time(nullable: false, precision: 7),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.ClientOffer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 4000),
                        photo = c.Binary(),
                        details = c.String(maxLength: 4000),
                        Start = c.DateTime(nullable: false, storeType: "date"),
                        end = c.DateTime(nullable: false, storeType: "date"),
                        Timeofpuplishing = c.Time(nullable: false, precision: 7),
                        Dateofpuplishing = c.DateTime(nullable: false, storeType: "date"),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.GalleryPhoto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        photo = c.Binary(),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Neighborhood",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(maxLength: 256),
                        EngName = c.String(maxLength: 256),
                        FrenchName = c.String(maxLength: 256),
                        RussName = c.String(maxLength: 256),
                        PersianName = c.String(maxLength: 256),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(maxLength: 256),
                        EngName = c.String(maxLength: 256),
                        FrenchName = c.String(maxLength: 256),
                        RussName = c.String(maxLength: 256),
                        PersianName = c.String(maxLength: 256),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.State", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(maxLength: 256),
                        EngName = c.String(maxLength: 256),
                        FrenchName = c.String(maxLength: 256),
                        RussName = c.String(maxLength: 256),
                        PersianName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShopDal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(maxLength: 4000),
                        EngName = c.String(maxLength: 4000),
                        FrenchName = c.String(maxLength: 4000),
                        RussName = c.String(maxLength: 4000),
                        PersianName = c.String(maxLength: 4000),
                        ArabicinvesterName = c.String(maxLength: 4000),
                        EnginvesterName = c.String(maxLength: 4000),
                        FrenchinvesterName = c.String(maxLength: 4000),
                        RussinvesterName = c.String(maxLength: 4000),
                        PersianinvesterName = c.String(maxLength: 4000),
                        SubCategoryDalId = c.Int(nullable: false),
                        UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCategoryDal", t => t.SubCategoryDalId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.SubCategoryDalId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Follower",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Email = c.String(maxLength: 256),
                        Numberofpictures = c.Int(),
                        AddOffers = c.Boolean(),
                        Addnotifications = c.Boolean(),
                        Addbranches = c.Boolean(),
                        NumberOfImagesAddedToranches = c.Int(),
                        numOfBranches = c.Int(),
                        AddCustomeNotifications = c.Boolean(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                        PhoneNumber = c.String(maxLength: 4000),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 256),
                        CreationDate = c.DateTime(nullable: false, storeType: "date"),
                        hasToken = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Claim",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DeviceToken",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.String(maxLength: 4000),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Favourite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(maxLength: 4000),
                        EngName = c.String(maxLength: 4000),
                        FrenchName = c.String(maxLength: 4000),
                        RussName = c.String(maxLength: 4000),
                        PersianName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategoryDal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        num = c.Int(),
                        ArabicName = c.String(maxLength: 4000),
                        EngName = c.String(maxLength: 4000),
                        FrenchName = c.String(maxLength: 4000),
                        iconEn = c.Binary(),
                        iconFr = c.Binary(),
                        iconPersian = c.Binary(),
                        iconRuss = c.Binary(),
                        RussName = c.String(maxLength: 4000),
                        PersianName = c.String(maxLength: 4000),
                        icon = c.Binary(),
                        MainCategoryDalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainCategoryDal", t => t.MainCategoryDalId, cascadeDelete: true)
                .Index(t => t.MainCategoryDalId);
            
            CreateTable(
                "dbo.MainCategoryDal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        num = c.Int(),
                        ArabicName = c.String(maxLength: 4000),
                        EngName = c.String(maxLength: 4000),
                        FrenchName = c.String(maxLength: 4000),
                        RussName = c.String(maxLength: 4000),
                        PersianName = c.String(maxLength: 4000),
                        icon = c.Binary(),
                        iconEn = c.Binary(),
                        iconFr = c.Binary(),
                        iconPersian = c.Binary(),
                        iconRuss = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExternalLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        senderId = c.Guid(nullable: false),
                        title = c.String(maxLength: 4000),
                        content = c.String(),
                        date = c.DateTime(storeType: "date"),
                        time = c.Time(precision: 7),
                        RevieverId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.RevieverId, cascadeDelete: true)
                .Index(t => t.RevieverId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Numberofpictures = c.Int(nullable: false),
                        numOfBranches = c.Int(nullable: false),
                        AddCustomeNotifications = c.Boolean(nullable: false),
                        AddOffers = c.Boolean(nullable: false),
                        Addnotifications = c.Boolean(nullable: false),
                        Addbranches = c.Boolean(nullable: false),
                        NumberOfImagesAddedToranches = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 2),
                        ArabicName = c.String(nullable: false, maxLength: 100),
                        EnglishName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainCategoryOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        num = c.Int(),
                        ArabicName = c.String(maxLength: 4000),
                        EngName = c.String(maxLength: 4000),
                        FrenchName = c.String(maxLength: 4000),
                        RussName = c.String(maxLength: 4000),
                        PersianName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategetoryOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        num = c.Int(),
                        ArabicName = c.String(maxLength: 4000),
                        EngName = c.String(maxLength: 4000),
                        FrenchName = c.String(maxLength: 4000),
                        RussName = c.String(maxLength: 4000),
                        PersianName = c.String(maxLength: 4000),
                        MainCategoryOffersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainCategoryOffers", t => t.MainCategoryOffersId, cascadeDelete: true)
                .Index(t => t.MainCategoryOffersId);
            
            CreateTable(
                "dbo.Offer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Atitle = c.String(maxLength: 4000),
                        Etitle = c.String(maxLength: 4000),
                        Ftitle = c.String(maxLength: 4000),
                        Ptitle = c.String(maxLength: 4000),
                        Rtitle = c.String(maxLength: 4000),
                        photo = c.Binary(),
                        photo1 = c.Binary(),
                        photo2 = c.Binary(),
                        photo3 = c.Binary(),
                        Adetails = c.String(maxLength: 4000),
                        Edetails = c.String(maxLength: 4000),
                        Fdetails = c.String(maxLength: 4000),
                        Pdetails = c.String(maxLength: 4000),
                        Rdetails = c.String(maxLength: 4000),
                        phon1 = c.String(maxLength: 4000),
                        phon2 = c.String(maxLength: 4000),
                        phon3 = c.String(maxLength: 4000),
                        phon4 = c.String(maxLength: 4000),
                        phon5 = c.String(maxLength: 4000),
                        phon6 = c.String(maxLength: 4000),
                        email = c.String(maxLength: 4000),
                        faceLink = c.String(maxLength: 4000),
                        instaLink = c.String(maxLength: 4000),
                        Whatsphon = c.String(maxLength: 4000),
                        Start = c.DateTime(storeType: "date"),
                        end = c.DateTime(storeType: "date"),
                        Timeofpuplishing = c.Time(nullable: false, precision: 7),
                        Dateofpuplishing = c.DateTime(nullable: false, storeType: "date"),
                        SubCategetoryOffersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCategetoryOffers", t => t.SubCategetoryOffersId, cascadeDelete: true)
                .Index(t => t.SubCategetoryOffersId);
            
            CreateTable(
                "dbo.Follower_ShopDal",
                c => new
                    {
                        FId = c.Int(nullable: false),
                        SId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FId, t.SId })
                .ForeignKey("dbo.Follower", t => t.FId, cascadeDelete: true)
                .ForeignKey("dbo.ShopDal", t => t.SId, cascadeDelete: true)
                .Index(t => t.FId)
                .Index(t => t.SId);
            
            CreateTable(
                "dbo.FavouriteSubCategoryDal",
                c => new
                    {
                        fId = c.Int(nullable: false),
                        sId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.fId, t.sId })
                .ForeignKey("dbo.Favourite", t => t.fId, cascadeDelete: true)
                .ForeignKey("dbo.SubCategoryDal", t => t.sId, cascadeDelete: true)
                .Index(t => t.fId)
                .Index(t => t.sId);
            
            CreateTable(
                "dbo.User_Favourite",
                c => new
                    {
                        favouritId = c.Int(nullable: false),
                        userId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.favouritId, t.userId })
                .ForeignKey("dbo.Favourite", t => t.favouritId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.userId, cascadeDelete: true)
                .Index(t => t.favouritId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategetoryOffers", "MainCategoryOffersId", "dbo.MainCategoryOffers");
            DropForeignKey("dbo.Offer", "SubCategetoryOffersId", "dbo.SubCategetoryOffers");
            DropForeignKey("dbo.Branch", "ShopDalId", "dbo.ShopDal");
            DropForeignKey("dbo.ShopDal", "UserId", "dbo.User");
            DropForeignKey("dbo.ShopDal", "SubCategoryDalId", "dbo.SubCategoryDal");
            DropForeignKey("dbo.Follower", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Notification", "RevieverId", "dbo.User");
            DropForeignKey("dbo.ExternalLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.User_Favourite", "userId", "dbo.User");
            DropForeignKey("dbo.User_Favourite", "favouritId", "dbo.Favourite");
            DropForeignKey("dbo.FavouriteSubCategoryDal", "sId", "dbo.SubCategoryDal");
            DropForeignKey("dbo.FavouriteSubCategoryDal", "fId", "dbo.Favourite");
            DropForeignKey("dbo.SubCategoryDal", "MainCategoryDalId", "dbo.MainCategoryDal");
            DropForeignKey("dbo.DeviceToken", "UserId", "dbo.User");
            DropForeignKey("dbo.Claim", "UserId", "dbo.User");
            DropForeignKey("dbo.Follower_ShopDal", "SId", "dbo.ShopDal");
            DropForeignKey("dbo.Follower_ShopDal", "FId", "dbo.Follower");
            DropForeignKey("dbo.Branch", "NeighborhoodId", "dbo.Neighborhood");
            DropForeignKey("dbo.Neighborhood", "RegionId", "dbo.Region");
            DropForeignKey("dbo.Region", "StateId", "dbo.State");
            DropForeignKey("dbo.GalleryPhoto", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.ClientOffer", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.Break", "BranchId", "dbo.Branch");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.User_Favourite", new[] { "userId" });
            DropIndex("dbo.User_Favourite", new[] { "favouritId" });
            DropIndex("dbo.FavouriteSubCategoryDal", new[] { "sId" });
            DropIndex("dbo.FavouriteSubCategoryDal", new[] { "fId" });
            DropIndex("dbo.Follower_ShopDal", new[] { "SId" });
            DropIndex("dbo.Follower_ShopDal", new[] { "FId" });
            DropIndex("dbo.Offer", new[] { "SubCategetoryOffersId" });
            DropIndex("dbo.SubCategetoryOffers", new[] { "MainCategoryOffersId" });
            DropIndex("dbo.Notification", new[] { "RevieverId" });
            DropIndex("dbo.ExternalLogin", new[] { "UserId" });
            DropIndex("dbo.SubCategoryDal", new[] { "MainCategoryDalId" });
            DropIndex("dbo.DeviceToken", new[] { "UserId" });
            DropIndex("dbo.Claim", new[] { "UserId" });
            DropIndex("dbo.Follower", new[] { "User_UserId" });
            DropIndex("dbo.ShopDal", new[] { "UserId" });
            DropIndex("dbo.ShopDal", new[] { "SubCategoryDalId" });
            DropIndex("dbo.Region", new[] { "StateId" });
            DropIndex("dbo.Neighborhood", new[] { "RegionId" });
            DropIndex("dbo.GalleryPhoto", new[] { "BranchId" });
            DropIndex("dbo.ClientOffer", new[] { "BranchId" });
            DropIndex("dbo.Break", new[] { "BranchId" });
            DropIndex("dbo.Branch", new[] { "NeighborhoodId" });
            DropIndex("dbo.Branch", new[] { "ShopDalId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.User_Favourite");
            DropTable("dbo.FavouriteSubCategoryDal");
            DropTable("dbo.Follower_ShopDal");
            DropTable("dbo.Offer");
            DropTable("dbo.SubCategetoryOffers");
            DropTable("dbo.MainCategoryOffers");
            DropTable("dbo.Language");
            DropTable("dbo.Role");
            DropTable("dbo.Notification");
            DropTable("dbo.ExternalLogin");
            DropTable("dbo.MainCategoryDal");
            DropTable("dbo.SubCategoryDal");
            DropTable("dbo.Favourite");
            DropTable("dbo.DeviceToken");
            DropTable("dbo.Claim");
            DropTable("dbo.User");
            DropTable("dbo.Follower");
            DropTable("dbo.ShopDal");
            DropTable("dbo.State");
            DropTable("dbo.Region");
            DropTable("dbo.Neighborhood");
            DropTable("dbo.GalleryPhoto");
            DropTable("dbo.ClientOffer");
            DropTable("dbo.Break");
            DropTable("dbo.Branch");
        }
    }
}
