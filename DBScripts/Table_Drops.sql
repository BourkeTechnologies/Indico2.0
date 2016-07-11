USE [Indico]
GO

--BEGIN TRAN

/****** Object:  Table [dbo].[PackingListCartonItem]    Script Date: 4/18/2016 7:19:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PackingListCartonItem]') AND type in (N'U'))
DROP TABLE [dbo].[PackingListCartonItem]
GO

/****** Object:  Table [dbo].[PackingListSizeQty]    Script Date: 4/18/2016 7:19:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PackingListSizeQty]') AND type in (N'U'))
DROP TABLE [dbo].[PackingListSizeQty]
GO

/****** Object:  Table [dbo].[PackingList]    Script Date: 4/18/2016 7:18:49 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PackingList]') AND type in (N'U'))
DROP TABLE [dbo].[PackingList]
GO

/****** Object:  Table [dbo].[Carton]    Script Date: 4/18/2016 7:06:13 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Carton]') AND type in (N'U'))
DROP TABLE [dbo].[Carton]
GO

/****** Object:  Table [dbo].[DefaultValuesPriceList]    Script Date: 4/18/2016 7:07:35 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DefaultValuesPriceList]') AND type in (N'U'))
DROP TABLE [dbo].[DefaultValuesPriceList]
GO

/****** Object:  Table [dbo].[DistributorPriceLevelCost]    Script Date: 4/18/2016 7:10:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DistributorPriceLevelCost]') AND type in (N'U'))
DROP TABLE [dbo].[DistributorPriceLevelCost]
GO

/****** Object:  Table [dbo].[DistributorPriceLevelCostHistory]    Script Date: 4/18/2016 7:11:10 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DistributorPriceLevelCostHistory]') AND type in (N'U'))
DROP TABLE [dbo].[DistributorPriceLevelCostHistory]
GO

/****** Object:  Table [dbo].[DistributorPriceMarkup]    Script Date: 4/18/2016 7:11:28 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DistributorPriceMarkup]') AND type in (N'U'))
DROP TABLE [dbo].[DistributorPriceMarkup]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Order_Invoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Invoice]
GO

ALTER TABLE dbo.[Order] 
	DROP COLUMN [Invoice]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_InvoiceOrder_Invoice]') AND parent_object_id = OBJECT_ID(N'[dbo].[InvoiceOrder]'))
ALTER TABLE [dbo].[InvoiceOrder] DROP CONSTRAINT [FK_InvoiceOrder_Invoice]
GO

/****** Object:  Table [dbo].[InvoiceOrder]    Script Date: 4/18/2016 7:14:24 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceOrder]') AND type in (N'U'))
DROP TABLE [dbo].[InvoiceOrder]
GO

/****** Object:  Table [dbo].[Invoice]    Script Date: 4/18/2016 7:13:53 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
DROP TABLE [dbo].[Invoice]
GO

/****** Object:  Table [dbo].[InvoiceStatus]    Script Date: 4/18/2016 7:14:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceStatus]') AND type in (N'U'))
DROP TABLE [dbo].[InvoiceStatus]
GO

/****** Object:  Table [dbo].[Keyword]    Script Date: 4/18/2016 7:16:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Keyword]') AND type in (N'U'))
DROP TABLE [dbo].[Keyword]
GO

/****** Object:  Table [dbo].[LabelPriceLevelCost]    Script Date: 4/18/2016 7:16:52 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LabelPriceLevelCost]') AND type in (N'U'))
DROP TABLE [dbo].[LabelPriceLevelCost]
GO

/****** Object:  Table [dbo].[LabelPriceListDownloads]    Script Date: 4/18/2016 7:17:38 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LabelPriceListDownloads]') AND type in (N'U'))
DROP TABLE [dbo].[LabelPriceListDownloads]
GO

/****** Object:  Table [dbo].[LabelPriceMarkup]    Script Date: 4/18/2016 7:18:27 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LabelPriceMarkup]') AND type in (N'U'))
DROP TABLE [dbo].[LabelPriceMarkup]
GO

/****** Object:  Table [dbo].[PriceHistroy]    Script Date: 4/18/2016 7:20:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceHistroy]') AND type in (N'U'))
DROP TABLE [dbo].[PriceHistroy]
GO

/****** Object:  Table [dbo].[PriceLevelCost]    Script Date: 4/18/2016 7:20:25 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceLevelCost]') AND type in (N'U'))
DROP TABLE [dbo].[PriceLevelCost]
GO

/****** Object:  Table [dbo].[PriceRemarks]    Script Date: 4/18/2016 7:22:16 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceRemarks]') AND type in (N'U'))
DROP TABLE [dbo].[PriceRemarks]
GO

/****** Object:  Table [dbo].[FactoryPriceRemarks]    Script Date: 4/19/2016 10:30:46 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FactoryPriceRemarks]') AND type in (N'U'))
DROP TABLE [dbo].[FactoryPriceRemarks]
GO

/****** Object:  Table [dbo].[IndimanPriceRemarks]    Script Date: 4/19/2016 10:31:00 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IndimanPriceRemarks]') AND type in (N'U'))
DROP TABLE [dbo].[IndimanPriceRemarks]
GO

/****** Object:  Table [dbo].[Price]    Script Date: 4/18/2016 7:19:35 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Price]') AND type in (N'U'))
DROP TABLE [dbo].[Price]
GO

/****** Object:  Table [dbo].[PriceChangeEmailList]    Script Date: 4/18/2016 7:19:50 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceChangeEmailList]') AND type in (N'U'))
DROP TABLE [dbo].[PriceChangeEmailList]
GO

/****** Object:  Table [dbo].[PriceLevel]    Script Date: 4/18/2016 7:20:15 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceLevel]') AND type in (N'U'))
DROP TABLE [dbo].[PriceLevel]
GO

/****** Object:  Table [dbo].[PriceListDownloads]    Script Date: 4/18/2016 7:21:45 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceListDownloads]') AND type in (N'U'))
DROP TABLE [dbo].[PriceListDownloads]
GO

/****** Object:  Table [dbo].[PriceMarkupLabel]    Script Date: 4/18/2016 7:21:57 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceMarkupLabel]') AND type in (N'U'))
DROP TABLE [dbo].[PriceMarkupLabel]
GO

/****** Object:  View [dbo].[PendingPricesView]    Script Date: 4/19/2016 12:05:54 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[PendingPricesView]'))
DROP VIEW [dbo].[PendingPricesView]
GO

/****** Object:  View [dbo].[DistributorNullPatternPriceLevelCostView]    Script Date: 4/19/2016 12:07:26 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[DistributorNullPatternPriceLevelCostView]'))
DROP VIEW [dbo].[DistributorNullPatternPriceLevelCostView]
GO

/****** Object:  View [dbo].[DistributorPatternPriceLevelCostView]    Script Date: 4/19/2016 12:07:26 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[DistributorPatternPriceLevelCostView]'))
DROP VIEW [dbo].[DistributorPatternPriceLevelCostView]
GO

/****** Object:  StoredProcedure [dbo].[SPC_DeletePrice]    Script Date: 4/19/2016 12:22:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_DeletePrice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_DeletePrice]
GO

/****** Object:  StoredProcedure [dbo].[SPC_GetCartonsDetails]    Script Date: 4/19/2016 12:22:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_GetCartonsDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_GetCartonsDetails]
GO

/****** Object:  StoredProcedure [dbo].[SPC_GetPackingListDetails]    Script Date: 4/19/2016 12:22:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_GetPackingListDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_GetPackingListDetails]
GO

/****** Object:  StoredProcedure [dbo].[SPC_CreatePackingList]    Script Date: 4/19/2016 12:22:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_CreatePackingList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_CreatePackingList]
GO

/****** Object:  StoredProcedure [dbo].[SPC_DeletePrice]    Script Date: 4/19/2016 12:22:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_DeletePrice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_DeletePrice]
GO

/****** Object:  StoredProcedure [dbo].[SPC_GetPrice]    Script Date: 4/19/2016 12:22:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_GetPrice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_GetPrice]
GO

/****** Object:  StoredProcedure [dbo].[SPC_CloneDistributorPriceMarkup]    Script Date: 4/19/2016 12:22:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_CloneDistributorPriceMarkup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_CloneDistributorPriceMarkup]
GO

/****** Object:  StoredProcedure [dbo].[SPC_CloneLabelPriceMarkup]    Script Date: 4/19/2016 12:22:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_CloneLabelPriceMarkup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_CloneLabelPriceMarkup]
GO

/****** Object:  StoredProcedure [dbo].[SPC_DeleteDistributorPriceMarkup]    Script Date: 4/19/2016 12:22:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_DeleteDistributorPriceMarkup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_DeleteDistributorPriceMarkup]
GO

/****** Object:  StoredProcedure [dbo].[SPC_GetIndimanPriceListData]    Script Date: 4/19/2016 1:33:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_GetIndimanPriceListData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_GetIndimanPriceListData]
GO

/****** Object:  StoredProcedure [dbo].[SPC_ReturnDownloadPriceList]    Script Date: 4/19/2016 1:34:47 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_ReturnDownloadPriceList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_ReturnDownloadPriceList]
GO

/****** Object:  StoredProcedure [dbo].[SPC_DeleteLabelPriceMarkup]    Script Date: 4/19/2016 1:35:15 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPC_DeleteLabelPriceMarkup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SPC_DeleteLabelPriceMarkup]
GO


--ROLLBACK TRAN





