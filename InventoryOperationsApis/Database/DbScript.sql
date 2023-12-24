USE [master]
GO
/****** Object:  Database [InventoryDb]    Script Date: 24-12-2023 10:16:00 ******/
CREATE DATABASE [InventoryDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventoryDb', FILENAME = N'C:\Sanket\Projects\InventoryOperationsApis\InventoryOperationsApis\Database\InventoryDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventoryDb_log', FILENAME = N'C:\Sanket\Projects\InventoryOperationsApis\InventoryOperationsApis\Database\InventoryDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [InventoryDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventoryDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventoryDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventoryDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InventoryDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventoryDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventoryDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventoryDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventoryDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventoryDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InventoryDb] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventoryDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventoryDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventoryDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventoryDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InventoryDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [InventoryDb] SET QUERY_STORE = OFF
GO
USE [InventoryDb]
GO
/****** Object:  User [inventoryuser]    Script Date: 24-12-2023 10:16:00 ******/
CREATE USER [inventoryuser] FOR LOGIN [inventoryuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [inventoryuser]
GO
/****** Object:  Table [dbo].[mst_brands]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_brands](
	[bran_id] [bigint] IDENTITY(1,1) NOT NULL,
	[bran_name] [nvarchar](100) NULL,
	[bran_IsActive] [char](1) NULL,
	[bran_IsDeleted] [char](1) NULL,
 CONSTRAINT [PK_mst_brands] PRIMARY KEY CLUSTERED 
(
	[bran_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_items]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_items](
	[item_id] [bigint] IDENTITY(1,1) NOT NULL,
	[item_name] [nvarchar](100) NULL,
	[item_IsActive] [char](1) NULL,
	[item_IsDeleted] [char](1) NULL,
 CONSTRAINT [PK_mst_items] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trn_inventory]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trn_inventory](
	[inve_id] [bigint] IDENTITY(1,1) NOT NULL,
	[inve_item_id] [bigint] NULL,
	[inve_bran_id] [bigint] NULL,
	[inve_color] [nvarchar](50) NULL,
	[inve_size] [nvarchar](50) NULL,
	[inve_gender] [nchar](10) NULL,
	[inve_price] [float] NULL,
	[inve_quantity] [int] NULL,
	[inve_IsActive] [char](1) NULL,
	[inve_IsDeleted] [char](1) NULL,
 CONSTRAINT [PK_trn_inventory] PRIMARY KEY CLUSTERED 
(
	[inve_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[mst_brands] ADD  CONSTRAINT [DF_mst_brands_bran_IsActive]  DEFAULT ('Y') FOR [bran_IsActive]
GO
ALTER TABLE [dbo].[mst_brands] ADD  CONSTRAINT [DF_mst_brands_bran_IsDeleted]  DEFAULT ('N') FOR [bran_IsDeleted]
GO
ALTER TABLE [dbo].[mst_items] ADD  CONSTRAINT [DF_mst_items_item_IsActive]  DEFAULT ('Y') FOR [item_IsActive]
GO
ALTER TABLE [dbo].[mst_items] ADD  CONSTRAINT [DF_mst_items_item_IsDeleted]  DEFAULT ('N') FOR [item_IsDeleted]
GO
ALTER TABLE [dbo].[trn_inventory] ADD  CONSTRAINT [DF_trn_inventory_inve_IsActive]  DEFAULT ('Y') FOR [inve_IsActive]
GO
ALTER TABLE [dbo].[trn_inventory] ADD  CONSTRAINT [DF_trn_inventory_inve_IsDeleted]  DEFAULT ('N') FOR [inve_IsDeleted]
GO
/****** Object:  StoredProcedure [dbo].[sp_brand_by_id_select]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[sp_brand_by_id_select]
(
-- Add the parameters for the stored procedure here
  @bran_id bigint=0
)
as
BEGIN	
	BEGIN TRY

		SET NOCOUNT ON;

		DECLARE @Temp TABLE  
		(			
			BrandId bigint,
			BrandName nvarchar(100)			
		)  
		
		INSERT INTO @Temp(BrandId,BrandName)  
		SELECT bran_id,bran_name
		FROM mst_brands		
		WHERE bran_IsDeleted='N' and bran_IsActive='Y' 
		and bran_id=@bran_id
  
		declare @IsSuccess bit=0
		declare @ResponseStatus nvarchar(max)='400'
		declare @Msg nvarchar(max)='Bad request'
		declare @ReturnID bigint=0	

		IF not Exists(select * from @Temp)
		BEGIN 

			set @ResponseStatus='404'
			set @Msg='Brand not found!'
			set @IsSuccess =0
			set @ReturnID=0

			select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId		 
		END
		else
		BEGIN
			SELECT @ReturnID=SCOPE_IDENTITY()
			set @ResponseStatus='200'
			set @Msg='Data received successfully'
			set @IsSuccess =1

			select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId
			
			select BrandId,BrandName from @Temp

		end

	END TRY
	BEGIN CATCH
		select 0 as IsSuccess,
		 'DBERROR' as FieldName,
		 'PROC  = ' + ERROR_PROCEDURE() + ' LINE =' + cast(ERROR_LINE() as varchar) + 'MSG =' + Error_Message() FieldMsg, -999 as ReturnId
	END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[sp_brands_list]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_brands_list]
as
BEGIN	
	BEGIN TRY

		SET NOCOUNT ON;
		  
		declare @IsSuccess bit=0
		declare @ResponseStatus nvarchar(max)='400'
		declare @Msg nvarchar(max)='Bad request'
		declare @ReturnID bigint=0	

		
		SELECT @ReturnID=SCOPE_IDENTITY()
		set @ResponseStatus='200'
		set @Msg='Data received successfully'
		set @IsSuccess =1

		select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title, @ReturnID as ReturnId

		select 0 as BrandId, '-Select' as BrandName
		union
		select bran_id as BrandId,bran_name as BrandName from mst_brands
		WHERE bran_IsDeleted='N' and bran_IsActive='Y'
			   
	END TRY
	BEGIN CATCH
		select 0 as IsSuccess,
		 'DBERROR' as FieldName,
		 'PROC  = ' + ERROR_PROCEDURE() + ' LINE =' + cast(ERROR_LINE() as varchar) + 'MSG =' + Error_Message() FieldMsg, -999 as ReturnId
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_inventories_view]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_inventories_view]
(
-- Add the parameters for the stored procedure here
  @FilterTerm nvarchar(250) = NULL --parameter to search all columns by  
, @SortIndex INT = 1 -- a one based index to indicate which column to order by  
, @SortDirection CHAR(4) = 'ASC' --the direction to sort in, either ASC or DESC  
, @StartRowNum INT = 1 --the first row to return  
, @EndRowNum INT = 10 --the last row to return  
, @TotalRowsCount INT OUTPUT  
, @FilteredRowsCount INT OUTPUT
)
as
BEGIN	
	BEGIN TRY

		SET NOCOUNT ON;

		SET @FilterTerm = '%' + @FilterTerm + '%'  
		DECLARE @Temp TABLE  
		(
			InventoryId bigint, 
			ItemId bigint,
			ItemName nvarchar(100),
			BrandId bigint,
			BrandName nvarchar(100),
			Color nvarchar(50),
			Size nvarchar(50),
			Gender nvarchar(10),
			Price float,
			Quantity int,
			IsActive char(1),			
			RowNum INT  
		)  
		
		INSERT INTO @Temp(InventoryId,ItemId,ItemName,BrandId,BrandName,Color,Size,Gender,Price,Quantity,IsActive,RowNum)  
		SELECT inve_id,inve_item_id,item_name,inve_bran_id,bran_name,inve_color,inve_size,inve_gender,inve_price,inve_quantity,inve_IsActive,
		Row_Number() OVER (  
		ORDER BY  	
			CASE @SortDirection  
			WHEN 'ASC' THEN  
				CASE @SortIndex  
					WHEN 2 THEN item_name  
					WHEN 3 THEN bran_name
				END         
			END ASC,  
			CASE @SortDirection  
				WHEN 'DESC' THEN   
				CASE @SortIndex  
					WHEN 2 THEN item_name  
					WHEN 3 THEN bran_name
				END  
		END DESC 
		) AS RowNum  
		
		FROM trn_inventory
		inner join mst_brands on bran_id=inve_bran_id
		inner join mst_items on item_id=inve_item_id
		WHERE inve_IsDeleted='N' and bran_IsDeleted='N' and item_IsDeleted='N' 
		and 
		(
			(@FilterTerm IS NULL)
			OR (item_name LIKE @FilterTerm )	
			OR (bran_name LIKE @FilterTerm )
		)
  
		declare @IsSuccess bit=0
		declare @ResponseStatus nvarchar(max)='400'
		declare @Msg nvarchar(max)='Bad request'
		declare @ReturnID bigint=0	

		IF not Exists(select * from @Temp  
						WHERE RowNum BETWEEN @StartRowNum AND @EndRowNum)
		BEGIN 

			set @ResponseStatus='404'
			set @Msg='Data not found!'
			set @IsSuccess =0
			set @ReturnID=0

			select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId		 
		END
		else
		BEGIN
			SELECT @ReturnID=SCOPE_IDENTITY()
			set @ResponseStatus='200'
			set @Msg='Data received successfully'
			set @IsSuccess =1

			select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId
			
			select InventoryId,ItemId,ItemName,BrandId,BrandName,Color,Size,Gender,Price,Quantity,IsActive,RowNum from @Temp
			WHERE RowNum BETWEEN @StartRowNum AND @EndRowNum

			select @TotalRowsCount=count(*) FROM  @Temp

			select @FilteredRowsCount=count(*) FROM  @Temp
			WHERE RowNum BETWEEN @StartRowNum AND @EndRowNum

			select @FilteredRowsCount as iTotalDisplayRecords, @TotalRowsCount as iTotalRecords
		end

	END TRY
	BEGIN CATCH
		select 0 as IsSuccess,
		 'DBERROR' as FieldName,
		 'PROC  = ' + ERROR_PROCEDURE() + ' LINE =' + cast(ERROR_LINE() as varchar) + 'MSG =' + Error_Message() FieldMsg, -999 as ReturnId
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_inventory_by_id_view]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_inventory_by_id_view]
(
-- Add the parameters for the stored procedure here
  @inve_id bigint=0
)
as
BEGIN	
	BEGIN TRY

		SET NOCOUNT ON;

		DECLARE @Temp TABLE  
		(
			InventoryId bigint, 
			ItemId bigint,
			ItemName nvarchar(100),
			BrandId bigint,
			BrandName nvarchar(100),
			Color nvarchar(50),
			Size nvarchar(50),
			Gender nvarchar(10),
			Price float,
			Quantity int,
			IsActive char(1)
		)  
		
		INSERT INTO @Temp(InventoryId,ItemId,ItemName,BrandId,BrandName,Color,Size,Gender,Price,Quantity,IsActive)  
		SELECT inve_id,inve_item_id,item_name,inve_bran_id,bran_name,inve_color,inve_size,inve_gender,inve_price,inve_quantity,inve_IsActive
		FROM trn_inventory
		inner join mst_brands on bran_id=inve_bran_id
		inner join mst_items on item_id=inve_item_id
		WHERE inve_IsDeleted='N' and bran_IsDeleted='N' and item_IsDeleted='N' 
		and inve_id=@inve_id
  
		declare @IsSuccess bit=0
		declare @ResponseStatus nvarchar(max)='400'
		declare @Msg nvarchar(max)='Bad request'
		declare @ReturnID bigint=0	

		IF not Exists(select * from @Temp)
		BEGIN 

			set @ResponseStatus='404'
			set @Msg='Data not found!'
			set @IsSuccess =0
			set @ReturnID=0

			select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId		 
		END
		else
		BEGIN
			SELECT @ReturnID=SCOPE_IDENTITY()
			set @ResponseStatus='200'
			set @Msg='Data received successfully'
			set @IsSuccess =1

			select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId
			
			select InventoryId,ItemId,ItemName,BrandId,BrandName,Color,Size,Gender,Price,Quantity,IsActive from @Temp

		end

	END TRY
	BEGIN CATCH
		select 0 as IsSuccess,
		 'DBERROR' as FieldName,
		 'PROC  = ' + ERROR_PROCEDURE() + ' LINE =' + cast(ERROR_LINE() as varchar) + 'MSG =' + Error_Message() FieldMsg, -999 as ReturnId
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[sp_inventory_by_itemid_view]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_inventory_by_itemid_view]
(
-- Add the parameters for the stored procedure here
  @inve_item_id bigint=0
)
as
BEGIN	
	BEGIN TRY

		SET NOCOUNT ON;

		DECLARE @Temp TABLE  
		(
			InventoryId bigint, 
			ItemId bigint,
			ItemName nvarchar(100),
			BrandId bigint,
			BrandName nvarchar(100),
			Color nvarchar(50),
			Size nvarchar(50),
			Gender nvarchar(10),
			Price float,
			Quantity int,
			IsActive char(1)
		)  
		
		INSERT INTO @Temp(InventoryId,ItemId,ItemName,BrandId,BrandName,Color,Size,Gender,Price,Quantity,IsActive)  
		SELECT inve_id,inve_item_id,item_name,inve_bran_id,bran_name,inve_color,inve_size,inve_gender,inve_price,inve_quantity,inve_IsActive
		FROM trn_inventory
		inner join mst_brands on bran_id=inve_bran_id
		inner join mst_items on item_id=inve_item_id
		WHERE inve_IsDeleted='N' and bran_IsDeleted='N' and item_IsDeleted='N' 
		and inve_item_id=@inve_item_id
  
		declare @IsSuccess bit=0
		declare @ResponseStatus nvarchar(max)='400'
		declare @Msg nvarchar(max)='Bad request'
		declare @ReturnID bigint=0	

		IF not Exists(select * from @Temp)
		BEGIN 

			set @ResponseStatus='404'
			set @Msg='Data not found!'
			set @IsSuccess =0
			set @ReturnID=0

			select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId		 
		END
		else
		BEGIN
			SELECT @ReturnID=SCOPE_IDENTITY()
			set @ResponseStatus='200'
			set @Msg='Data received successfully'
			set @IsSuccess =1

			select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId
			
			select InventoryId,ItemId,ItemName,BrandId,BrandName,Color,Size,Gender,Price,Quantity,IsActive from @Temp

		end

	END TRY
	BEGIN CATCH
		select 0 as IsSuccess,
		 'DBERROR' as FieldName,
		 'PROC  = ' + ERROR_PROCEDURE() + ' LINE =' + cast(ERROR_LINE() as varchar) + 'MSG =' + Error_Message() FieldMsg, -999 as ReturnId
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[sp_inventory_delete]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_inventory_delete]
(
@inve_id bigint=null
)
as
begin
	
	begin try

		declare @IsSuccess bit=0
		declare @ResponseStatus nvarchar(max)='400'
		declare @Msg nvarchar(max)='Bad request'
		declare @ReturnID bigint=0	

		if not Exists(select * from trn_inventory where inve_id=@inve_id and inve_IsDeleted='N')
		begin 

			set @ResponseStatus='404'
			set @Msg='Data not found!'
			set @IsSuccess =0
			set @ReturnID=0
	 
		end
		else
		begin

			update trn_inventory
			set inve_IsDeleted='Y'
			where inve_id=@inve_id
			
			SELECT @ReturnID=SCOPE_IDENTITY()
			set @ResponseStatus='200'
			set @Msg='Data deleted successfully'
			set @IsSuccess =1

		end

		select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId

	end try
	begin catch
		select 0 as IsSuccess,
		 'DBERROR' as FieldName,
		 'PROC  = ' + ERROR_PROCEDURE() + ' LINE =' + cast(ERROR_LINE() as varchar) + 'MSG =' + Error_Message() FieldMsg, -999 as ReturnId
	end catch
end

GO
/****** Object:  StoredProcedure [dbo].[sp_inventory_insert]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_inventory_insert]
(
@inve_item_id bigint=null,
@inve_bran_id bigint=null,
@inve_color nvarchar(50)=null,
@inve_size nvarchar(50)=null,
@inve_gender nvarchar(10)=null,
@inve_price float=null,
@inve_quantity int=null
)
as
begin
	
	begin try

			declare @IsSuccess bit=0
			declare @ResponseStatus nvarchar(max)='400'
			declare @Msg nvarchar(max)='Bad request'
			declare @ReturnID bigint=0	

			declare @inve_id bigint

		if Exists(select * from trn_inventory where inve_item_id=@inve_item_id and inve_bran_id=@inve_bran_id and inve_IsDeleted='N')
		begin 

			set @ResponseStatus='400'
			set @Msg='Action Failed! Duplicate data found!'
			set @IsSuccess =0
			set @ReturnID=0
	 
		end
		else
		begin

				insert into trn_inventory(inve_item_id,inve_bran_id,inve_color,inve_size,inve_gender,inve_price,inve_quantity) 
				values (@inve_item_id,@inve_bran_id,@inve_color,@inve_size,@inve_gender,@inve_price,@inve_quantity)

				set @inve_id=@@IDENTITY

				SELECT @ReturnID=SCOPE_IDENTITY()
				set @ResponseStatus='200'
				set @Msg='Data added successfully'
				set @IsSuccess =1

		end

		select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId

	end try
	begin catch
		select 0 as IsSuccess,
		 'DBERROR' as FieldName,
		 'PROC  = ' + ERROR_PROCEDURE() + ' LINE =' + cast(ERROR_LINE() as varchar) + 'MSG =' + Error_Message() FieldMsg, -999 as ReturnId
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[sp_inventory_update]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_inventory_update]
(
@inve_id bigint=null,
@inve_item_id bigint=null,
@inve_bran_id bigint=null,
@inve_color nvarchar(50)=null,
@inve_size nvarchar(50)=null,
@inve_gender nvarchar(10)=null,
@inve_price float=null,
@inve_quantity int=null
)
as
begin
	
	begin try

		declare @IsSuccess bit=0
		declare @ResponseStatus nvarchar(max)='400'
		declare @Msg nvarchar(max)='Bad request'
		declare @ReturnID bigint=0	

		if Exists(select * from trn_inventory where inve_item_id=@inve_item_id and inve_bran_id=@inve_bran_id and inve_IsDeleted='N' and inve_id<>@inve_id)
		begin 

			set @ResponseStatus='400'
			set @Msg='Action Failed! Duplicate data found!'
			set @IsSuccess =0
			set @ReturnID=0
	 
		end
		else
		begin

			update trn_inventory
			set inve_item_id=@inve_item_id,
			inve_bran_id=@inve_bran_id,
			inve_color=@inve_color,
			inve_size=@inve_size,
			inve_gender=@inve_gender,
			inve_price=@inve_price,
			inve_quantity=@inve_quantity
			where inve_id=@inve_id
			
			SELECT @ReturnID=SCOPE_IDENTITY()
			set @ResponseStatus='200'
			set @Msg='Data updated successfully'
			set @IsSuccess =1

		end

		select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId

	end try
	begin catch
		select 0 as IsSuccess,
		 'DBERROR' as FieldName,
		 'PROC  = ' + ERROR_PROCEDURE() + ' LINE =' + cast(ERROR_LINE() as varchar) + 'MSG =' + Error_Message() FieldMsg, -999 as ReturnId
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[sp_item_by_id_select]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_item_by_id_select]
(
-- Add the parameters for the stored procedure here
  @item_id bigint=0
)
as
BEGIN	
	BEGIN TRY

		SET NOCOUNT ON;

		DECLARE @Temp TABLE  
		(			
			ItemId bigint,
			ItemName nvarchar(100)			
		)  
		
		INSERT INTO @Temp(ItemId,ItemName)  
		SELECT item_id,item_name
		FROM mst_items		
		WHERE item_IsDeleted='N' and item_IsActive='Y' 
		and item_id=@item_id
  
		declare @IsSuccess bit=0
		declare @ResponseStatus nvarchar(max)='400'
		declare @Msg nvarchar(max)='Bad request'
		declare @ReturnID bigint=0	

		IF not Exists(select * from @Temp)
		BEGIN 

			set @ResponseStatus='404'
			set @Msg='Item not found!'
			set @IsSuccess =0
			set @ReturnID=0

			select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId		 
		END
		else
		BEGIN
			SELECT @ReturnID=SCOPE_IDENTITY()
			set @ResponseStatus='200'
			set @Msg='Data received successfully'
			set @IsSuccess =1

			select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title,@ReturnID as ReturnId
			
			select ItemId,ItemName from @Temp

		end

	END TRY
	BEGIN CATCH
		select 0 as IsSuccess,
		 'DBERROR' as FieldName,
		 'PROC  = ' + ERROR_PROCEDURE() + ' LINE =' + cast(ERROR_LINE() as varchar) + 'MSG =' + Error_Message() FieldMsg, -999 as ReturnId
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[sp_items_list]    Script Date: 24-12-2023 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_items_list]
as
BEGIN	
	BEGIN TRY

		SET NOCOUNT ON;
		  
		declare @IsSuccess bit=0
		declare @ResponseStatus nvarchar(max)='400'
		declare @Msg nvarchar(max)='Bad request'
		declare @ReturnID bigint=0	

		
		SELECT @ReturnID=SCOPE_IDENTITY()
		set @ResponseStatus='200'
		set @Msg='Data received successfully'
		set @IsSuccess =1

		select @IsSuccess as IsSuccess,@ResponseStatus as [Status],  @Msg as Title, @ReturnID as ReturnId

		select 0 as ItemId, '-Select' as ItemName
		union
		select item_id as ItemId,item_name as ItemName from mst_items
		WHERE item_IsDeleted='N' and item_IsActive='Y'
			   
	END TRY
	BEGIN CATCH
		select 0 as IsSuccess,
		 'DBERROR' as FieldName,
		 'PROC  = ' + ERROR_PROCEDURE() + ' LINE =' + cast(ERROR_LINE() as varchar) + 'MSG =' + Error_Message() FieldMsg, -999 as ReturnId
	END CATCH
END

GO
USE [master]
GO
ALTER DATABASE [InventoryDb] SET  READ_WRITE 
GO
