--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**

/****** Object:  Table [dbo].[Role]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](4) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[DisplayName] [nvarchar](64) NOT NULL,
	[Priority] int NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The key of the Role' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Key'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Role' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The display name of the Role' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'DisplayName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Role priority' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Priority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role'
GO

--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**

/****** Object:  Table [dbo].[ControllerAction]    Script Date: 07-Apr-2016 9:07:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ControllerAction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Controller] [nvarchar](128) NOT NULL,
	[Action] [nvarchar](128) NULL,
	[Parameters] [nvarchar](128) NULL,
 CONSTRAINT [TBL_ControllerAction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ControllerAction', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Name of the Controller' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ControllerAction', @level2type=N'COLUMN',@level2name=N'Controller'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Name of the Controller Action' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ControllerAction', @level2type=N'COLUMN',@level2name=N'Action'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Parameeters of the Controller Action' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ControllerAction', @level2type=N'COLUMN',@level2name=N'Parameters'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ControllerAction'
GO

--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**

/****** Object:  Table [dbo].[MenuItem]    Script Date: 07-Apr-2016 9:05:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MenuItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ControllerAction] [int] NOT NULL,
	[Parent] [int] NULL,
	[Position] [int] NOT NULL,
	[IsAlignedLeft] [bit] NOT NULL,
	[IsSubNav] [bit] NOT NULL,
	[IsTopNav] [bit] NOT NULL,
	[IsVisible] [bit] NOT NULL,
	[Key] [nvarchar](4) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_MenuItem_ControllerAction] FOREIGN KEY([ControllerAction])
REFERENCES [dbo].[ControllerAction] ([ID])
GO

ALTER TABLE [dbo].[MenuItem] CHECK CONSTRAINT [FK_MenuItem_ControllerAction]
GO

ALTER TABLE [dbo].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_MenuItem_Parent] FOREIGN KEY([Parent])
REFERENCES [dbo].[MenuItem] ([ID])
GO

ALTER TABLE [dbo].[MenuItem] CHECK CONSTRAINT [FK_MenuItem_Parent]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The page' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'ControllerAction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent of the Menu item' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'Parent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Menu item position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'Position'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identify to weather manu item is aligned to left or right?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'IsAlignedLeft'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is sub navigation?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'IsSubNav'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Menu item is placed inside main or top level menu?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'IsTopNav'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Menu item visible?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'IsVisible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The key of the menu item' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'Key'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the menu item' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the menu item' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItem'
GO

--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**

/****** Object:  Table [dbo].[MenuItemRole]    Script Date: 07-Apr-2016 9:08:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MenuItemRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuItem] [int] NOT NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_MenuItemRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MenuItemRole]  WITH CHECK ADD  CONSTRAINT [FK_MenuItemRole_MenuItem] FOREIGN KEY([MenuItem])
REFERENCES [dbo].[MenuItem] ([ID])
GO

ALTER TABLE [dbo].[MenuItemRole] CHECK CONSTRAINT [FK_MenuItemRole_MenuItem]
GO

ALTER TABLE [dbo].[MenuItemRole]  WITH CHECK ADD  CONSTRAINT [FK_MenuItemRole_Role] FOREIGN KEY([Role])
REFERENCES [dbo].[Role] ([ID])
GO

ALTER TABLE [dbo].[MenuItemRole] CHECK CONSTRAINT [FK_MenuItemRole_Role]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItemRole', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ID of the menu item' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItemRole', @level2type=N'COLUMN',@level2name=N'MenuItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ID of the account type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItemRole', @level2type=N'COLUMN',@level2name=N'Role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuItemRole'
GO

--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**--**

DECLARE @MenuItemId int
DECLARE @ParentMenuItemId int


INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,2,0,0,1,1,'ORD','Orders','Orders');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId



  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'ORD','Orders','Orders');
SET @MenuItemId = SCOPE_IDENTITY()




INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,2,0,0,1,1,'ORD','Orders','Orders');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'ORD','Orders','Orders');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,1,'ORD','Order Types','Order Types');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,5,0,1,0,1,'LAB','Labels','Labels');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,6,0,1,0,1,'DES','Destination Ports','Destination Ports');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,7,0,1,0,1,'PAY','Payment Terms','Payment Terms');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,8,0,1,0,1,'SHI','Shipment Modes','Shipment Modes');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,9,0,1,0,0,'PAC','Packing Plan','Packing Plan');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,10,0,1,0,0,'PAC','Packing Lists','Packing Lists');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,11,0,1,0,0,'FIL','Fill Carton','Fill Carton');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,12,0,1,0,0,'CAR','Cartons','Cartons');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,72,0,1,0,1,'ORD','Order Status','Order Status');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,144,0,1,0,1,'ORD','Order Detail Status','Order Detail Status');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,145,0,1,0,0,'ORD','Order Drill Down','Order Drill Down');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,145,0,1,0,0,'ORD','Order Drill Down','Order Drill Down');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,3,0,0,1,1,'INV','Invoices','Invoices');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'FAC','Factory Invoices','Factory Invoices');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,1,'IND','Indiman Invoices','Indiman Invoices');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,4,0,0,1,1,'PAT','Patterns','Patterns');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'PAT','Patterns','Patterns');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,1,'ACC','Accessories','Accessories');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,3,0,1,0,1,'ACC','Accessory Categories','Accessory Categories');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,4,0,1,0,1,'ACC','Accessory Colors','Pattern Accessory Colors');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,5,0,1,0,1,'PAT','Pattern Accessories','Pattern Accessories');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,6,0,1,0,1,'MEA','Measurements','Measurements');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,7,0,1,0,1,'ITE','Items','Items');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,8,0,1,0,1,'ATT','Attributes','Attributes');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,9,0,1,0,1,'FAB','Fabrics','Fabric Codes');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,10,0,1,0,1,'CAT','Categories','Categories');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,11,0,1,0,1,'HS ','HS Codes','HS Codes');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,12,0,1,0,0,'COM','Compare Garment Specifications','Compare Garment Specifications');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,13,0,1,0,1,'PAT','Pattern Descriptions Grids','Pattern Descriptions Grid');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,14,0,1,0,0,'FAB','Fabric Code','Fabric Code');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,15,0,1,0,1,'PAT','Pattern Development','Pattern Development');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,6,0,0,1,1,'RES','Reservations','Reservations');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,0,'RES','Reservation','Reservation');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,7,0,0,1,1,'PRO','Products','Products');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,0,'PRO','Product','Product');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,0,'ART','Art Work','Art Work');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,8,0,0,1,1,'MAS','Master Data','Master Data');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'AGE','Age Groups','Age Groups');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,1,'COL','Color Profiles','Color Profiles');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,3,0,1,0,1,'EMA','Email Logo','Email Logo');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,4,0,1,0,1,'GEN','Gender','Gender');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,5,0,1,0,1,'PRI','Printers','Printers');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,6,0,1,0,1,'PRI','Print Types','Print Types');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,7,0,1,0,1,'PRO','Production Lines','Production Lines');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,8,0,1,0,1,'RES','Resolution Profiles','Resolution Profiles');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,9,0,1,0,1,'SIZ','Sizes','Sizes');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,10,0,1,0,1,'SIZ','Size Sets','Size Sets');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,11,0,1,0,1,'SUP','Suppliers','Suppliers');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,12,0,1,0,1,'UNI','Units','Units');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,13,0,1,0,1,'FAB','Fabric Types','Fabric Types');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,14,0,1,0,1,'EMB','Embroidery Status','Embroidery Status');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,15,0,1,0,1,'ADD','Addresses','Shipment Addresses');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,16,0,1,0,1,'PAT','Pattern Suppliers','Pattern Suppliers');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,17,0,1,0,1,'POR','Ports','View/Edit/Delete/Add Ports');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,9,0,0,1,1,'SET','Settings','Settings');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'INF','Information','Information');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,1,'PRO','Profile','Profile');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,3,0,1,0,1,'PHO','Photo','Photo');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,4,0,1,0,1,'PAS','Password','Password');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,10,0,0,1,1,'MAN','Manage','Manage');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'USE','Users','Users');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,1,'COM','Companies','Companies');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,3,0,1,0,1,'DIS','Distributors','Distributors');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,4,0,1,0,1,'JOB','Job Names','Job Names');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,5,0,1,0,1,'MYO','MYOB Card File','MYOB Card File');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,6,0,1,0,1,'SET','Settings','Settings');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,6,0,1,0,1,'CLI','Clients','Clients');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,1);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,5,0,0,1,1,'PRI','Prices','Prices');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,0,'PAT','Pattern Prices','Pattern Prices');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'MAN','Manage Pattern Fabric','Manage Pattern Fabric');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,0,'FAC','Factory Prices','Factory Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,4,0,1,0,1,'COS','Cost Sheets','Cost Sheets');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,6,0,1,0,1,'FAC','Factory Price','Factory Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,5,0,0,1,1,'PRI','Prices','Prices');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,0,'IND','Indiman Prices','Indiman Prices');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,1,'MAN','Manage Pattern Fabric','Manage Pattern Fabric');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,3,0,1,0,0,'IND','Indico Prices','Indico Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,4,0,1,0,0,'FAC','Factory Prices','Factory Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,5,0,1,0,1,'PRI','Price Levels','Price Levels');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,6,0,1,0,0,'PRI','Price Markups','Price Markups');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,7,0,1,0,0,'PEN','Pending Prices','Prices Prices');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,8,0,1,0,0,'DOW','Download To Excel','Download To Excel');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,8,0,1,0,0,'ADD','Add Price List','Add Price List');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,10,0,1,0,1,'COS','Cost Sheets','Cost Sheets');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,11,0,1,0,1,'IND','Indico CIF Price','Indico CIF Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,11,0,1,0,1,'IND','Indiman CIF Price','Indiman CIF Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,12,0,1,0,1,'IND','Indico FOB Price','Indico FOB Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,12,0,1,0,1,'IND','Indiman FOB Price','Indiman FOB Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,13,0,1,0,1,'FAC','Factory Price','Factory Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,5,0,0,1,1,'PRI','Prices','Prices');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,0,'IND','Indico Prices','Indico Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,0,'PRI','Price Markups','Price Markups');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,3,0,1,0,0,'DOW','Download to Excel','Download to Excel');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,4,0,1,0,1,'IND','Indico CIF Price','Indico CIF Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,5,0,1,0,1,'IND','Indico FOB Price','Indico FOB Price');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,11,0,0,1,1,'QUO','Quotes','Quotes');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'QUO','Quotes','Quotes');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,1,0,0,1,1,'DAS','Dashboard','Dashboard');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'WEE','Weekly Summaries - Pieces','Weekly Summaries - Pieces');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,1,'WEE','Weekly Summaries - SMV','Weekly Summaries - SMV');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,3,0,1,0,0,'ORD','Order DrillDown','Order DrillDown');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,8);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,9);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,1,0,0,1,1,'DAS','Dashboard','Dashboard');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,0,0,1,0,1,'CUR','Current & Forthcomming Week Details','Current & Forthcomming Week Details');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'PRO','Production Capacities','Production Capacities');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,1,'WEE','Weekly Summaries','Weekly Summaries');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,3,0,1,0,0,'WEE','Week Details','Week Details');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,4,0,1,0,0,'WEE','Week Summary','Week Summary');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,5,0,1,0,0,'HOM','Home','Home');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,6,0,1,0,1,'BAC','Back Orders','Back Orders');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,7,0,1,0,1,'PRO','Production Planning','Production Planning');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,8,0,1,0,1,'WEE','Weekly Summary (Backorders)','Weekly Summary (Backorders)');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,3);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,5);

INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,12,0,0,1,1,'EMB','Embroideries','Embroideries');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'EMB','Embroideries','Embroideries');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,0,'EMB','Embroidery','Embroidery');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,8,0,0,1,1,'MAS','Master Data','Master Data');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,1,'FAB','Fabric Types','Fabric Types');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,1,'BAN','Banks','Banks');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,2);



INSERT INTO [dbo].[MenuItem] (ControllerAction,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,13,0,0,1,1,'REP','Reports','Reports');
SET @MenuItemId = SCOPE_IDENTITY()
SET @ParentMenuItemId = @MenuItemId

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,1,0,1,0,0,'SAL','Sales Report','Sales Report');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,2,0,1,0,0,'DET','Detail Report','Detail Report');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,3,0,1,0,1,'SAL','Sales Grid Report','Sales Grid Report');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,4,0,1,0,0,'DRI','Drill Down Report','Drill Down Report');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);


  INSERT INTO [dbo].[MenuItem] (ControllerAction,Parent,Position,IsAlignedLeft,IsSubNav,IsTopNav,IsVisible,[Key],Name,Title) VALUES(1,@ParentMenuItemId,5,0,1,0,0,'DRI','Drill Down Report By Client','Drill Down Report By Client');
SET @MenuItemId = SCOPE_IDENTITY()

INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,4);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,6);
INSERT INTO [dbo].[MenuItemRole] (MenuItem,Role) VALUES(@MenuItemId,7);
